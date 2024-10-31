using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Partnership_Module
{
	public class PartnershipRepository : IPartnershipRepository
	{
		private readonly MageCompendiumContext _context;

		public PartnershipRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async void ConcludePartnershipAsync(Partnership partnership)
		{
			partnership.ConcludePartnership();

			await _context.SaveChangesAsync();
		}

		public async Task AddPartnershipAsync(Partnership partnership)
		{
			_context.Partnerships.Add(partnership);

			await _context.SaveChangesAsync();
		}

		public async Task DeletePartnershipAsync(int id)
		{
			var partnership = await _context.Partnerships.FindAsync(id);

			if (partnership != null)
			{
				_context.Partnerships.Remove(partnership);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Partnership>> GetAllPartnershipsAsync()
		{
			return await _context.Partnerships.ToListAsync();
		}

		public int GetLengthOfPartnershipInMonths(Partnership partnership)
		{
			return partnership.GetLengthOfPartnershipInMonths();
		}

		public async Task<Partnership?> GetPartnershipByIdAsync(int id)
		{
			return await _context.Partnerships.FindAsync(id);
		}
	}
}
