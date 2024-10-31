using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using System;

namespace FP_EN_Brusnikau_s24109.Services.Miscellaneous
{
	internal class NavigationService : ObservableObject, INavigationService
	{
		private ViewModel _currentView;
		private readonly Func<Type, ViewModel> _viewModelFactory;

		public ViewModel CurrentView
		{
			get => _currentView;
			private set
			{
				_currentView = value;

				OnPropertyChanged();
			}
		}

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
		{
			_viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
		{
			CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
		}
	}
}
