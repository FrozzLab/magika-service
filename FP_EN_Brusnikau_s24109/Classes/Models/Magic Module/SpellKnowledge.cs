using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class SpellKnowledge
	{
		private DateTime _learningDate = DateTime.Now;
        public DateTime LearningDate => _learningDate; 

		public LevelOfUnderstanding LevelOfUnderstanding { get; set; }

		public int CostOfKnowledge => CalculateCostOfKnowledgeForGivenUnderstanding(LevelOfUnderstanding);

		public int IdMage { get; init; }
		public Mage Mage { get; init; } = null!;

		public int IdSpell { get; init; }
		public BaseSpell Spell { get; init; } = null!;

		private int CalculateCostOfKnowledgeForGivenUnderstanding(LevelOfUnderstanding level)
		{
			return Spell.PowerLevelCost + (int)level;
		}

		public void ImproveSpellUnderstanding(LevelOfUnderstanding desiredLevel)
		{
			if ((int)desiredLevel <= (int)LevelOfUnderstanding)
			{
				throw new ArgumentException
				(
					"Cannot improve understanding as the spell knowledge is already equal to or higher than the desired level."
				);
			}

			if (Mage.currentPowerLevel < CalculateCostOfKnowledgeForGivenUnderstanding(desiredLevel) - CostOfKnowledge)
			{
				throw new ArgumentException
				(
					"Cannot improve understanding as the mage lacks free power level to afford it."
				);
			}

			LevelOfUnderstanding = desiredLevel;
		}
    }
}
