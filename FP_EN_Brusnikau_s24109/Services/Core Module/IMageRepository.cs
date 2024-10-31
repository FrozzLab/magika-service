using FP_EN_Brusnikau_s24109.Classes.DTOs.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Core_Module
{
	public interface IMageRepository
	{
		Task<IEnumerable<Mage>> GetAllMagesAsync();
		
		Task<Mage?> GetMageByIdAsync(int id);
		
		Task AddMageAsync(Mage mage);
		
		Task DeleteMageAsync(int id);
		
		Task AddAttunedDomainAsync(Mage mage, ArcaneDomain domain);
		
		Task RemoveAttunedDomainAsync(Mage mage, ArcaneDomain domain);
		
		Task<Application> SendOutApplicationForPartnershipAsync(ApplicationDTO applicationDTO);
		
		Task<Mage?> GetMageWithHighestTotalPowerLevelAsync();
	}
}
