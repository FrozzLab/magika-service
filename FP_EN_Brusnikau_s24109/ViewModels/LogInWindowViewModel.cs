using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using FP_EN_Brusnikau_s24109.Services.Miscellaneous;

namespace FP_EN_Brusnikau_s24109.ViewModels
{
	public class LogInWindowViewModel : ViewModel
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

		public LogInWindowViewModel(INavigationService navigationService)
		{
			Navigation = navigationService;

			Navigation.NavigateTo<LogInViewModel>();
		}
	}
}
