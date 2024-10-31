using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;

namespace FP_EN_Brusnikau_s24109.Classes.DTOs.Partnership_Module
{
	public class ApplicationDTO
	{
		public Mage Mage { get; init; }
		public Benefactor Benefactor { get; init; }
		public string Title { get; init; }
		public PartnershipGoal Goal { get; init; }
		public string Description { get; init; }
		public float InitialOffer { get; init; }

		public ApplicationDTO(Mage mage, Benefactor benefactor, string title, 
			PartnershipGoal goal, string description, float offerValue)
		{
			Mage = mage;
			Benefactor = benefactor;
			Title = title;
			Goal = goal;
			Description = description;
			InitialOffer = offerValue;
		}
	}
}
