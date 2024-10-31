using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class MageAttunedDomain
	{
		public int IdMage { get; init; }
		public Mage Mage { get; init; } = null!;

		public int IdArcaneDomain { get; init; }
		public ArcaneDomain ArcaneDomain { get; init; } = null!;
	}
}
