using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Partnership_Module
{
	public interface IPartnershipRepository
	{
		Task<IEnumerable<Partnership>> GetAllPartnershipsAsync();

		Task<Partnership?> GetPartnershipByIdAsync(int id);

		Task AddPartnershipAsync(Partnership partnership);

		Task DeletePartnershipAsync(int id);

		int GetLengthOfPartnershipInMonths(Partnership partnership);

		void ConcludePartnershipAsync(Partnership partnership);
	}
}
