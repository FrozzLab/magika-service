using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Magic_Module
{
	public class SpellRepository : ISpellRepository
	{
		private readonly MageCompendiumContext _context;

		public SpellRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddSpellAsync(BaseSpell spell)
		{
			_context.Spells.Add(spell);

			await _context.SaveChangesAsync();
		}

		public float CalculateCastPrice(BaseSpell spell)
		{
			return spell.CalculateCastPrice();
		}

		public async Task DeleteSpellAsync(int id)
		{
			var spell = await _context.Spells.FindAsync(id);

			if (spell != null)
			{
				_context.Spells.Remove(spell);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<BaseSpell>> GetAllSpellsAsync()
		{
			return await _context.Spells.ToListAsync();
		}

		public async Task<BaseSpell?> GetSpellByIdAsync(int id)
		{
			return await _context.Spells.FindAsync(id);
		}
	}
}
