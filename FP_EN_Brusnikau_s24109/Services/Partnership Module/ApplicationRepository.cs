using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Partnership_Module
{
	public class ApplicationRepository : IApplicationRepository
	{
		private readonly MageCompendiumContext _context;

		public ApplicationRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async void CancelNegotiationsAsync(Application application)
		{
			application.CancelNegotiations();

			await _context.SaveChangesAsync();
		}

		public async Task ConcludeNegotiationsAsync(Application application)
		{
			var partnership = application.ConcludeNegotiations();

			await _context.Partnerships.AddAsync(partnership);

			_context.Applications.Update(application);

			partnership.Mage.Partnerships.Add(partnership);
			_context.Mages.Update(partnership.Mage);

			partnership.Benefactor.Partnerships.Add(partnership);
			_context.Benefactors.Update(partnership.Benefactor);

			await _context.SaveChangesAsync();
		}

		public async Task AddApplicationAsync(Application application)
		{
			_context.Applications.Add(application);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteApplicationAsync(int id)
		{
			var application = await _context.Applications.FindAsync(id);

			if (application != null)
			{
				_context.Applications.Remove(application);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
		{
			return await _context.Applications.ToListAsync();
		}

		public async Task<Application?> GetApplicationByIdAsync(int id)
		{
			return await _context.Applications.FindAsync(id);
		}

		public async void MakeOfferAsync(Application application, float value, OfferingSide side)
		{
			application.MakeOffer(value, side);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Mage>> GetAllApplicantsAsync()
		{
			return await _context.Applications.Select(a => a.Mage).ToListAsync();
		}

		public IEnumerable<Application> GetAllApplicationsByBenefactor(Benefactor benefactor)
		{
			_context.Entry(benefactor)
				.Collection(b => b.Applications)
				.Load();

			return benefactor.Applications;
		}

		public IEnumerable<Mage> GetAllApplicantsByBenefactor(Benefactor benefactor)
		{
			_context.Entry(benefactor)
				.Collection(b => b.Applications)
				.Load();

			foreach (var application in benefactor.Applications)
			{
				_context.Entry(application)
					.Reference(a => a.Mage)
					.Load();
			}

			return benefactor.Applications.Select(a => a.Mage);
		}

		public IEnumerable<Application> GetApplicationsByApplicantAndBenefactor(Mage applicant, Benefactor benefactor)
		{
			_context.Entry(applicant)
				.Collection(a => a.Applications)
				.Load();

			foreach (var application in applicant.Applications)
			{
				_context.Entry(application)
					.Reference(a => a.Benefactor)
					.Load();
			}

			return applicant.Applications.Where(a => a.Benefactor == benefactor);
		}

		public Mage GetApplicantByApplication(Application application)
		{
			_context.Entry(application)
				.Reference(a => a.Mage)
				.Load();

			return application.Mage;
		}
	}
}
