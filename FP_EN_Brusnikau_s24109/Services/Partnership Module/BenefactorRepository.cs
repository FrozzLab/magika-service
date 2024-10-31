using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Partnership_Module
{
	public class BenefactorRepository : IBenefactorRepository
	{
		private readonly MageCompendiumContext _context;

		public BenefactorRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddBenefactorAsync(Benefactor benefactor)
		{
			_context.Benefactors.Add(benefactor);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteBenefactorAsync(int id)
		{
			var benefactor = await _context.Benefactors.FindAsync(id);

			if (benefactor != null)
			{
				_context.Benefactors.Remove(benefactor);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Benefactor>> GetAllBenefactorsAsync()
		{
			return await _context.Benefactors.ToListAsync();
		}

		public async Task<Benefactor?> GetBenefactorByIdAsync(int id)
		{
			return await _context.Benefactors.FindAsync(id);
		}

		public async Task<Benefactor?> GetBenefactorWithMostPartnershipsByTypeAsync(PartnershipGoal goal)
		{
			var benefactor = await _context.Benefactors
				.Where(b => b.Partnerships.Any(p => p.Goal == goal))
				.OrderByDescending(b => b.Partnerships.Count(p => p.Goal == goal))
				.FirstOrDefaultAsync();

			return benefactor;
		}

		public async Task<Benefactor?> GetHighestPayingBenefactorAsync()
		{
			var benefactor = await _context.Benefactors
				.OrderByDescending(b => b.Partnerships.Sum(p => p.CalculateTotalContribution()))
				.FirstOrDefaultAsync();

			return benefactor;
		}
	}
}
