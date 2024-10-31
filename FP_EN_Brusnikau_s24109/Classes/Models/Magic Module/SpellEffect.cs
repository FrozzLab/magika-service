using System;
using System.Collections.Generic;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public abstract class SpellEffect
	{
		public int IdSpellEffect { get; init; }

        public EffectType EffectType { get; init; }

		private List<CreatureType> _immuneCreatures = new();
        public List<CreatureType> ImmuneCreatures 
		{ 
			get => _immuneCreatures; 
			set
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of immune creatures."
					);
				}

				_immuneCreatures = value;
			}
		}

        private const int MinPotency = 1, MaxPotency = 10;

		private int _potency;
		public int Potency
		{
			get => _potency;
			init
			{
				if (value is < MinPotency or > MaxPotency)
				{
					throw new ArgumentException
					(
						$"Spell effect potency must be between {MinPotency} and {MaxPotency}."
					);
				}

				_potency = value;
			}
		}

		public int IdSpell { get; init; }
		public BaseSpell Spell { get; init; } = null!;
	}
}
