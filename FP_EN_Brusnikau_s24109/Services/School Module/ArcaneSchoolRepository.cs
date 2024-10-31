using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.School_Module
{
	public class ArcaneSchoolRepository : IArcaneSchoolRepository
	{
		private readonly MageCompendiumContext _context;

		public ArcaneSchoolRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddArcaneSchoolAsync(ArcaneSchool ArcaneSchool)
		{
			_context.ArcaneSchools.Add(ArcaneSchool);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteArcaneSchoolAsync(int id)
		{
			var ArcaneSchool = await _context.ArcaneSchools.FindAsync(id);

			if (ArcaneSchool != null)
			{
				_context.ArcaneSchools.Remove(ArcaneSchool);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<ArcaneSchool>> GetAllArcaneSchoolsAsync()
		{
			return await _context.ArcaneSchools.ToListAsync();
		}

		public async Task<ArcaneSchool?> GetArcaneSchoolByIdAsync(int id)
		{
			return await _context.ArcaneSchools.FindAsync(id);
		}

		public async Task<ArcaneSchool?> GetSchoolWithMostStudentsAsync()
		{
			return await _context.ArcaneSchools
				.OrderByDescending(s => s.Enrollments.Count)
				.FirstOrDefaultAsync();
		}

		public async void EnrollMageAsync(ArcaneSchool arcaneSchool, Mage mage, DegreeType degreeType)
		{
			var enrollment = arcaneSchool.EnrollMage(mage, degreeType);

			mage.Enrollments.Add(enrollment);

			_context.ArcaneSchools.Update(arcaneSchool);
			_context.Mages.Update(mage);

			await _context.SaveChangesAsync();
		}

		public async void ExpelMageAsync(ArcaneSchool arcaneSchool, Mage mage)
		{
			arcaneSchool.ExpelMage(mage);

			await _context.SaveChangesAsync();
		}

		public async void GraduateMageAsync(ArcaneSchool arcaneSchool, Mage mage)
		{
			arcaneSchool.GraduateMage(mage);

			await _context.SaveChangesAsync();
		}

		public async void AddTaughtDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain)
		{
			var tsd = arcaneSchool.AddTaughtDomain(arcaneDomain);

			arcaneDomain.TeachingSchools.Add(tsd);

			_context.ArcaneSchools.Update(arcaneSchool);
			_context.ArcaneDomains.Update(arcaneDomain);

			await _context.SaveChangesAsync();
		}

		public async void AddForbiddenDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain)
		{
			var fsd = arcaneSchool.AddForbiddenDomain(arcaneDomain);

			arcaneDomain.ForbiddingSchools.Add(fsd);

			_context.ArcaneSchools.Update(arcaneSchool);
			_context.ArcaneDomains.Update(arcaneDomain);

			await _context.SaveChangesAsync();
		}

		public async void RemoveTaughtDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain)
		{
			var tsd = arcaneSchool.RemoveTaughtDomain(arcaneDomain);

			arcaneDomain.TeachingSchools.Remove(tsd);

			_context.ArcaneSchools.Update(arcaneSchool);
			_context.ArcaneDomains.Update(arcaneDomain);

			await _context.SaveChangesAsync();
		}

		public async void RemoveForbiddenDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain)
		{
			var fsd = arcaneSchool.RemoveForbiddenDomain(arcaneDomain);

			arcaneDomain.ForbiddingSchools.Remove(fsd);

			_context.ArcaneSchools.Update(arcaneSchool);
			_context.ArcaneDomains.Update(arcaneDomain);

			await _context.SaveChangesAsync();
		}

		public void ToggleAddedDomain(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain)
		{
			var tsd = arcaneSchool.TaughtDomains.Select(tsd => tsd.ArcaneDomain).SingleOrDefault(arcaneDomain);
			var fsd = arcaneSchool.ForbiddenDomains.Select(fsd => fsd.ArcaneDomain).SingleOrDefault(arcaneDomain);

			if (tsd != null)
			{
				RemoveTaughtDomainAsync(arcaneSchool, arcaneDomain);
				AddForbiddenDomainAsync(arcaneSchool, arcaneDomain);
			}
			else if (fsd != null)
			{
				RemoveForbiddenDomainAsync(arcaneSchool, arcaneDomain);
				AddTaughtDomainAsync(arcaneSchool, arcaneDomain);
			}
		}
	}
}
