using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using FP_EN_Brusnikau_s24109.Services.Miscellaneous;

namespace FP_EN_Brusnikau_s24109.ViewModels
{
	public class LogInViewModel : ViewModel
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

        public RelayCommand BenefactorLogInCommand { get; set; }
        public RelayCommand MageLogInCommand { get; set; }

        public LogInViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;

            BenefactorLogInCommand = new RelayCommand(o => { Navigation.NavigateTo<BenefactorLogInViewModel>(); }, o => true);
			MageLogInCommand = new RelayCommand(o => { Navigation.NavigateTo<MageLogInViewModel>(); }, o => true);
		}
    }
}
