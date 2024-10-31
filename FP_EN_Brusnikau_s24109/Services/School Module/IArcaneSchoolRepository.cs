using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.School_Module
{
	public interface IArcaneSchoolRepository
	{
		Task<IEnumerable<ArcaneSchool>> GetAllArcaneSchoolsAsync();

		Task<ArcaneSchool?> GetArcaneSchoolByIdAsync(int id);

		Task AddArcaneSchoolAsync(ArcaneSchool arcaneSchool);

		Task DeleteArcaneSchoolAsync(int id);

		void EnrollMageAsync(ArcaneSchool arcaneSchool, Mage mage, DegreeType degreeType);

		void GraduateMageAsync(ArcaneSchool arcaneSchool, Mage mage);

		void ExpelMageAsync(ArcaneSchool arcaneSchool, Mage mage);

		void AddTaughtDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain);

		void RemoveTaughtDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain);

		void AddForbiddenDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain);

		void RemoveForbiddenDomainAsync(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain);

		void ToggleAddedDomain(ArcaneSchool arcaneSchool, ArcaneDomain arcaneDomain);

		Task<ArcaneSchool?> GetSchoolWithMostStudentsAsync(); 
	}
}
