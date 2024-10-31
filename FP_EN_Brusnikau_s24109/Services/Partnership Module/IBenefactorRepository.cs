using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Partnership_Module
{
	public interface IBenefactorRepository
	{
		Task<IEnumerable<Benefactor>> GetAllBenefactorsAsync();

		Task<Benefactor?> GetBenefactorByIdAsync(int id);

		Task AddBenefactorAsync(Benefactor benefactor);

		Task DeleteBenefactorAsync(int id);

		Task<Benefactor?> GetHighestPayingBenefactorAsync();

		Task<Benefactor?> GetBenefactorWithMostPartnershipsByTypeAsync(PartnershipGoal goal);
	}
}
