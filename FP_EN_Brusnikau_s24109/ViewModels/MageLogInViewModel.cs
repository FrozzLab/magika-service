using FP_EN_Brusnikau_s24109.Classes.Miscellaneous;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Services.Core_Module;
using FP_EN_Brusnikau_s24109.Services.Miscellaneous;
using System.Collections.Generic;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.ViewModels
{
	public class MageLogInViewModel : ViewModel
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

		private readonly IMageRepository _mageRepository;

		private List<Mage> _mages = new();
		public List<Mage> Mages
		{
			get => _mages;
			set
			{
				_mages = value;

				OnPropertyChanged();
			}
		}

		private async void LoadMages()
		{
			var magesEnumerable = await _mageRepository.GetAllMagesAsync();
			Mages = magesEnumerable.ToList();
		}

		public MageLogInViewModel(INavigationService navigationService, IMageRepository mageRepository)
		{
			Navigation = navigationService;
			_mageRepository = mageRepository;

			LoadMages();
		}
	}
}
