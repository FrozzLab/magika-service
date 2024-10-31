using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Magic_Module
{
	public class SpellKnowledgeRepository : ISpellKnowledgeRepository
	{
		private readonly MageCompendiumContext _context;

		public SpellKnowledgeRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddSpellKnowledgeAsync(SpellKnowledge SpellKnowledge)
		{
			_context.SpellsKnowledge.Add(SpellKnowledge);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteSpellKnowledgeAsync(int idMage, int idSpell)
		{
			var SpellKnowledge = await _context.SpellsKnowledge
				.SingleOrDefaultAsync(sk => sk.IdMage == idMage && sk.IdSpell == idSpell);

			if (SpellKnowledge != null)
			{
				_context.SpellsKnowledge.Remove(SpellKnowledge);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<SpellKnowledge>> GetAllSpellsKnowledgeAsync()
		{
			return await _context.SpellsKnowledge.ToListAsync();
		}

		public async Task<SpellKnowledge?> GetSpellKnowledgeByIdAsync(int idMage, int idSpell)
		{
			return await _context.SpellsKnowledge
				.SingleOrDefaultAsync(sk => sk.IdMage == idMage && sk.IdSpell == idSpell);
		}

		public async void ImproveSpellUnderstandingAsync(SpellKnowledge spellKnowledge, LevelOfUnderstanding desiredLevel)
		{
			spellKnowledge.ImproveSpellUnderstanding(desiredLevel);

			await _context.SaveChangesAsync();
		}
	}
}
