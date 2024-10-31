using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.Magic_Module
{
	public interface ISpellRepository
	{
		Task<IEnumerable<BaseSpell>> GetAllSpellsAsync();

		Task<BaseSpell?> GetSpellByIdAsync(int id);

		Task AddSpellAsync(BaseSpell spell);

		Task DeleteSpellAsync(int id);

		float CalculateCastPrice(BaseSpell spell);
	}
}
