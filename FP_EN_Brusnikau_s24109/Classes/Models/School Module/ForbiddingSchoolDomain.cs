using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;

namespace FP_EN_Brusnikau_s24109.Classes.Models.School_Module
{
	public class ForbiddingSchoolDomain
	{
		public int IdArcaneSchool { get; init; }
		public ArcaneSchool ArcaneSchool { get; init; } = null!;

		public int IdArcaneDomain { get; init; }
		public ArcaneDomain ArcaneDomain { get; init; } = null!;
    }
}
