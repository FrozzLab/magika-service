using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using FP_EN_Brusnikau_s24109.Services.Miscellaneous;
using FP_EN_Brusnikau_s24109.Services.Partnership_Module;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.ViewModels
{
	public class BenefactorLogInViewModel : ViewModel
	{
		private INavigationService _navigation;
		public INavigationService Navigation
		{
			get => _navigation;
			set
			{
				_navigation = value;

				OnPropertyChanged();
			}
		}

		private readonly IBenefactorRepository _benefactorRepository;

		private List<Benefactor> _benefactors = new();
		public List<Benefactor> Benefactors
		{ 
			get => _benefactors; 
			set
			{
				_benefactors = value;

				OnPropertyChanged();
			}
		}

		public static event Action<Benefactor> OnBenefactorSelected;

		public RelayCommand SelectBenefactorCommand { get; set; }

		public void SelectBenefactor(Benefactor benefactor)
		{
			Navigation.NavigateTo<BenefactorApplicationsViewModel>();
			OnBenefactorSelected.Invoke(benefactor);
		}

		private async void LoadBenefactors()
		{
			var benefactorsEnumerable = await  _benefactorRepository.GetAllBenefactorsAsync();
			Benefactors = benefactorsEnumerable.ToList();
		}

		public BenefactorLogInViewModel(INavigationService navigationService, IBenefactorRepository benefactorRepository)
		{
			Navigation = navigationService;
			_benefactorRepository = benefactorRepository;

			SelectBenefactorCommand = new RelayCommand(o => { SelectBenefactor(o as Benefactor); }, o => true);

			LoadBenefactors();
		}
	}
}
