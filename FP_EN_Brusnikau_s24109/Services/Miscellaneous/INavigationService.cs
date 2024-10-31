using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;

namespace FP_EN_Brusnikau_s24109.Services.Miscellaneous
{
	public interface INavigationService
	{
		ViewModel CurrentView { get; }

		void NavigateTo<T>() where T : ViewModel;
	}
}
