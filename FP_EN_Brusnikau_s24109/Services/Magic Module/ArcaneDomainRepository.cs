using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Magic_Module
{
	public class ArcaneDomainRepository : IArcaneDomainRepository
	{
		private readonly MageCompendiumContext _context;

		public ArcaneDomainRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddArcaneDomainAsync(ArcaneDomain ArcaneDomain)
		{
			_context.ArcaneDomains.Add(ArcaneDomain);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteArcaneDomainAsync(int id)
		{
			var arcaneDomain = await _context.ArcaneDomains.FindAsync(id);

			if (arcaneDomain != null)
			{
				_context.ArcaneDomains.Remove(arcaneDomain);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<ArcaneDomain?> FindMostAttunedToDomainAsync()
		{
			var arcaneDomain = await _context.ArcaneDomains
				.OrderByDescending(ad => ad.AttunedMages.Count)
				.FirstOrDefaultAsync();

			return arcaneDomain;
		}

		public async Task<IEnumerable<ArcaneDomain>> GetAllArcaneDomainsAsync()
		{
			return await _context.ArcaneDomains.ToListAsync();
		}

		public async Task<ArcaneDomain?> GetArcaneDomainByIdAsync(int id)
		{
			return await _context.ArcaneDomains.FindAsync(id);
		}
	}
}
