using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Magic_Module
{
	public interface IArcaneDomainRepository
	{
		Task<IEnumerable<ArcaneDomain>> GetAllArcaneDomainsAsync();

		Task<ArcaneDomain?> GetArcaneDomainByIdAsync(int id);

		Task AddArcaneDomainAsync(ArcaneDomain arcaneDomain);

		Task DeleteArcaneDomainAsync(int id);

		Task<ArcaneDomain?> FindMostAttunedToDomainAsync();
	}
}
