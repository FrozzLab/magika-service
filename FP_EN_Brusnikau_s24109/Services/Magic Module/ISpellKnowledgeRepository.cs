using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Magic_Module
{
	public interface ISpellKnowledgeRepository
	{
		Task<IEnumerable<SpellKnowledge>> GetAllSpellsKnowledgeAsync();

		Task<SpellKnowledge?> GetSpellKnowledgeByIdAsync(int idMage, int idSpell);

		Task AddSpellKnowledgeAsync(SpellKnowledge SpellKnowledge);

		Task DeleteSpellKnowledgeAsync(int idMage, int idSpell);

		void ImproveSpellUnderstandingAsync(SpellKnowledge spellKnowledge, LevelOfUnderstanding desiredLevel);
	}
}
