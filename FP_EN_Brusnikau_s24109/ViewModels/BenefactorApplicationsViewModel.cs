using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using FP_EN_Brusnikau_s24109.Services.Miscellaneous;
using FP_EN_Brusnikau_s24109.Services.Partnership_Module;
using System;
using System.Collections.ObjectModel;

namespace FP_EN_Brusnikau_s24109.ViewModels
{
	public class BenefactorApplicationsViewModel : ViewModel
	{
		private INavigationService _navigation;
		public INavigationService Navigation
		{
			get => _navigation;
			set
			{
				_navigation = value;

				OnPropertyChanged(nameof(Navigation));
			}
		}

		private readonly IApplicationRepository _applicationRepository;

		private ObservableCollection<Application> _applications = new();
		public ObservableCollection<Application> Applications
		{
			get => _applications;
			set
			{
				_applications = value;

				OnPropertyChanged(nameof(Applications));
			}
		}

		private ObservableCollection<Mage> _applicants = new();
		public ObservableCollection<Mage> Applicants
		{
			get => _applicants;
			set
			{
				_applicants = value;

				OnPropertyChanged(nameof(Applicants));
			}
		}

		private Benefactor _benefactor;

		private Application? _selectedApplication;
		public Application? SelectedApplication 
		{ 
			get => _selectedApplication;
			set
			{
				IsApplicationSelected = value != null;
				_selectedApplication = value;

				OnPropertyChanged(nameof(SelectedApplication));
				ParseGoal();
				ParseStatus();
				ParseOffers();
			}
		}

		private bool _isApplicationSelected = false;
		public bool IsApplicationSelected
		{
			get { return _isApplicationSelected; }
			set
			{
				if (_isApplicationSelected != value)
				{
					_isApplicationSelected = value;

					OnPropertyChanged(nameof(IsApplicationSelected));
				}
			}
		}

		private string _applicationGoal;
		public string ApplicationGoal
		{
			get => _applicationGoal;
			set
			{
				_applicationGoal = value;

				OnPropertyChanged(nameof(ApplicationGoal));
			}
		}

		private string _applicationStatus;
		public string ApplicationStatus
		{
			get => _applicationStatus;
			set
			{
				_applicationStatus = value;

				OnPropertyChanged(nameof(ApplicationStatus));
			}
		}

		private bool _isApplicationOngoing = false;
		public bool IsApplicationOngoing
		{
			get { return _isApplicationOngoing; }
			set
			{
				if (_isApplicationOngoing != value)
				{
					_isApplicationOngoing = value;

					OnPropertyChanged(nameof(IsApplicationOngoing));
				}
			}
		}

		private string _applicationOffers;
		public string ApplicationOffers
		{
			get => _applicationOffers;
			set
			{
				_applicationOffers = value;

				OnPropertyChanged(nameof(ApplicationOffers));
			}
		}

		private int _newOfferValue;
		public int NewOfferValue
		{
			get { return _newOfferValue; }
			set
			{
				_newOfferValue = value;

				OnPropertyChanged(nameof(NewOfferValue));
			}
		}

		private Mage? _selectedApplicant;
		public Mage? SelectedApplicant 
		{ 
			get => _selectedApplicant; 
			set
			{
				IsApplicantSelected = value != null;
				_selectedApplicant = value;

				OnPropertyChanged(nameof(SelectedApplicant));
			}
		}

		private bool _isApplicantSelected = false;
		public bool IsApplicantSelected
		{
			get { return _isApplicantSelected; }
			set
			{
				if (_isApplicantSelected != value)
				{
					_isApplicantSelected = value;

					OnPropertyChanged(nameof(IsApplicantSelected));
				}
			}
		}

		public RelayCommand SelectApplicantCommand { get; set; }

		public void SelectApplicant(Mage applicant)
		{
			if (SelectedApplicant != applicant)
			{
				SelectedApplicant = applicant;

				Applicants.Clear();
				Applicants.Add(applicant);

				Applications = new ObservableCollection<Application>(_applicationRepository
					.GetApplicationsByApplicantAndBenefactor(applicant, _benefactor));
			}
			else
			{
				SelectedApplicant = null;
				SelectedApplication = null;

				Applications.Clear();

				Applicants = new ObservableCollection<Mage>(_applicationRepository.GetAllApplicantsByBenefactor(_benefactor));
			}
		}

		public RelayCommand SelectApplicationCommand { get; set; }

		public void SelectApplication(Application application)
		{
			if (SelectedApplication != application)
			{
				SelectedApplication = application;

				Applicants.Clear();
				Applicants.Add(_applicationRepository.GetApplicantByApplication(application));

				Applications.Clear();
				Applications = new ObservableCollection<Application>(_applicationRepository
					.GetApplicationsByApplicantAndBenefactor(application.Mage, _benefactor));
			}
			else
			{
				SelectedApplication = null;
			}
		}

		public RelayCommand LoadApplicationsAndApplicantsCommand { get; set; }

		public void LoadApplicationsAndApplicants()
		{
			Applicants = new ObservableCollection<Mage>(_applicationRepository.GetAllApplicantsByBenefactor(_benefactor));
			Applications = new ObservableCollection<Application>(_applicationRepository.GetAllApplicationsByBenefactor(_benefactor));
		}

		public RelayCommand ReturnToLogInCommand { get; set; }

		public void ReturnToLogIn()
		{
			SelectedApplicant = null;
			SelectedApplication = null;

			Navigation.NavigateTo<BenefactorLogInViewModel>();
		}

		public RelayCommand LoadApplicantsCommand { get; set; }
		public void LoadApplicants()
		{
			Applicants = new ObservableCollection<Mage>(_applicationRepository.GetAllApplicantsByBenefactor(_benefactor));
		}

		private void ParseGoal()
		{
			if (SelectedApplication != null)
			{
				ApplicationGoal = SelectedApplication.Goal.ToString();
			}
			else
			{
				ApplicationGoal = string.Empty;
			}
		}

		private void ParseStatus()
		{
			if (SelectedApplication != null)
			{
				ApplicationStatus = SelectedApplication.Status.ToString();

				IsApplicationOngoing = (SelectedApplication.Status == Classes.ApplicationStatus.Ongoing 
					&& SelectedApplication.NextToRespond == Classes.OfferingSide.Benefactor);
			}
			else
			{
				ApplicationGoal = string.Empty;
			}
		}
		private void ParseOffers()
		{
			if (SelectedApplication != null)
			{
				ApplicationOffers = string.Empty;

				foreach (var offer in SelectedApplication.OfferHistory)
				{
					ApplicationOffers += $"{offer.OfferingSide}: {offer.OfferValue} Gold\n";
				}

				if (SelectedApplication.Status != Classes.ApplicationStatus.Ongoing)
				{
					ApplicationOffers += $"{ApplicationStatus}\n";
				}
			}
			else
			{
				ApplicationOffers = string.Empty;
			}
		}

		public RelayCommand CancelNegotiationsCommand { get; set; }
		public void CancelNegotiations()
		{
			if (SelectedApplication == null || !IsApplicationOngoing)
			{
				return;
			}

			_applicationRepository.CancelNegotiationsAsync(SelectedApplication);

			ParseStatus();
			ParseOffers();
		}

		public RelayCommand ConcludeNegotiationsCommand { get; set; }
		public void ConcludeNegotiations()
		{
			if (SelectedApplication == null || !IsApplicationOngoing)
			{
				return;
			}

			_applicationRepository.ConcludeNegotiationsAsync(SelectedApplication);

			ParseStatus();
			ParseOffers();
		}

		public RelayCommand MakeOfferCommand { get; set; }
		public void MakeOffer()
		{
			if (SelectedApplication == null || !IsApplicationOngoing)
			{
				return;
			}

			_applicationRepository.MakeOfferAsync(SelectedApplication, NewOfferValue, Classes.OfferingSide.Benefactor);

			ParseStatus();
			ParseOffers();
		}

		public BenefactorApplicationsViewModel(INavigationService navigationService, IApplicationRepository applicationRepository)
		{
			Navigation = navigationService;
			_applicationRepository = applicationRepository;

			SelectApplicantCommand = new RelayCommand(o => { SelectApplicant(o as Mage); }, o => true);
			SelectApplicationCommand = new RelayCommand(o => { SelectApplication(o as Application); }, o => true);
			LoadApplicantsCommand = new RelayCommand(o => { LoadApplicants(); }, o => true);
			LoadApplicationsAndApplicantsCommand = new RelayCommand(o => { LoadApplicationsAndApplicants(); }, o => true);
			ReturnToLogInCommand = new RelayCommand(o => { ReturnToLogIn(); }, o => true);
			CancelNegotiationsCommand = new RelayCommand(o => { CancelNegotiations(); }, o => true);
			ConcludeNegotiationsCommand = new RelayCommand(o => { ConcludeNegotiations(); }, o => true);
			MakeOfferCommand = new RelayCommand(o => { MakeOffer(); }, o => true);

			BenefactorLogInViewModel.OnBenefactorSelected += OnBenefactorSelected;
		}

		private void OnBenefactorSelected(Benefactor benefactor)
			{
			_benefactor = benefactor;

			LoadApplicants();
		}
	}
}
