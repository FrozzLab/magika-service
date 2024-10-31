using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Partnership_Module
{
	public interface IApplicationRepository
	{
		Task<IEnumerable<Application>> GetAllApplicationsAsync();

		Task<IEnumerable<Mage>> GetAllApplicantsAsync();

		Task<Application?> GetApplicationByIdAsync(int id);

		Task DeleteApplicationAsync(int id);

		Task AddApplicationAsync(Application application);

		Task ConcludeNegotiationsAsync(Application application);

		void CancelNegotiationsAsync(Application application);

		void MakeOfferAsync(Application application, float value, OfferingSide side);

		public IEnumerable<Application> GetAllApplicationsByBenefactor(Benefactor benefactor);

		public IEnumerable<Mage> GetAllApplicantsByBenefactor(Benefactor benefactor);

		public IEnumerable<Application> GetApplicationsByApplicantAndBenefactor(Mage applicant, Benefactor benefactor);

		public Mage GetApplicantByApplication(Application application);
	}
}
