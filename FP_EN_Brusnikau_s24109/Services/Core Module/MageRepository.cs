using FP_EN_Brusnikau_s24109.Classes.DTOs.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Core_Module
{
	public class MageRepository : IMageRepository
	{
		private readonly MageCompendiumContext _context;

		public MageRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddAttunedDomainAsync(Mage mage, ArcaneDomain domain)
		{
			var mageAttunedDomain = new MageAttunedDomain()
			{
				Mage = mage,
				ArcaneDomain = domain
			};

			_context.MagesAttunedDomains.Add(mageAttunedDomain);

			mage.AttunedDomains.Add(mageAttunedDomain);
			domain.AttunedMages.Add(mageAttunedDomain);

			_context.Mages.Update(mage);
			_context.ArcaneDomains.Update(domain);

			await _context.SaveChangesAsync();
		}

		public async Task AddMageAsync(Mage mage)
		{
			_context.Mages.Add(mage);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteMageAsync(int id)
		{
			var mage = await _context.Mages.FindAsync(id);

			if (mage != null)
			{
				_context.Mages.Remove(mage);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Mage>> GetAllMagesAsync()
		{
			return await _context.Mages.ToListAsync();
		}

		public async Task<Mage?> GetMageByIdAsync(int id)
		{
			return await _context.Mages.FindAsync(id);
		}

		public async Task RemoveAttunedDomainAsync(Mage mage, ArcaneDomain domain)
		{
			var mageAttunedDomain = await _context.MagesAttunedDomains.FindAsync(mage.IdMage, domain.IdArcaneDomain);

			if (mageAttunedDomain == null)
			{
				throw new ArgumentException
				(
					"Cannot remove attuned domain as the given mage is not attuned to it."
				);
			}

			_context.MagesAttunedDomains.Remove(mageAttunedDomain);

			mage.AttunedDomains.Remove(mageAttunedDomain);
			domain.AttunedMages.Remove(mageAttunedDomain);

			_context.Mages.Update(mage);
			_context.ArcaneDomains.Update(domain);

			await _context.SaveChangesAsync();
		}

		public async Task<Application> SendOutApplicationForPartnershipAsync(ApplicationDTO applicationDTO)
		{
			var mage = await _context.Mages.FindAsync(applicationDTO.Mage.IdMage);

			if (mage == null)
			{
				throw new ArgumentException
				(
					"Cannot send application as the provided mage does not exist in the database."
				);
			}

			var application = mage.SendOutApplicationForPartnership(applicationDTO);

			await _context.Applications.AddAsync(application);

			mage.Applications.Add(application);
			_context.Mages.Update(mage);

			application.Benefactor.Applications.Add(application);
			_context.Benefactors.Update(application.Benefactor);

			await _context.SaveChangesAsync();

			return application;
		}

		public async Task<Mage?> GetMageWithHighestTotalPowerLevelAsync()
		{
			return await _context.Mages
				.OrderByDescending(x => x.TotalPowerLevel)
				.FirstOrDefaultAsync();
		}
	}
}
