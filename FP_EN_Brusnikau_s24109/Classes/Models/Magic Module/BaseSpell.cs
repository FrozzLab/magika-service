using System;
using System.Collections.Generic;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
    public abstract class BaseSpell
    {
        public int IdSpell { get; init; }

        public const int MinNameLength = 5, MaxNameLength = 120;

        private string _name = null!;
        public string Name
        {
            get => _name;
            init
            {
                if (value.Length is < MinNameLength or > MaxNameLength)
                {
                    throw new ArgumentException
                    (
                        $"Spell name length must be between {MinNameLength} and {MaxNameLength} characters."
                    );
                }

                _name = value;
            }
        }

        private const int MinPowerLevelCost = 1, MaxPowerLevelCost = 10000;

        private int _powerLevelCost;
        public int PowerLevelCost
        {
            get => _powerLevelCost;
            init
            {
                if (value is < MinPowerLevelCost or > MaxPowerLevelCost)
                {
                    throw new ArgumentException
                    (
                        $"Spell power level cost must be between {MinPowerLevelCost} and {MaxPowerLevelCost}."
                    );
                }

                _powerLevelCost = value;
            }
        }

        public int IdArcaneDomain { get; init; }
        public ArcaneDomain ArcaneDomain { get; init; } = null!;

        private List<SpellKnowledge> _magesKnowledge = new();
        public List<SpellKnowledge> MagesKnowledge
        {
            get => new(_magesKnowledge);
            init
            {
                if (value.Count != value.Distinct().Count())
                {
                    throw new ArgumentException
                    (
                        "There can't be duplicates in the list of mages."
                    );
                }

                _magesKnowledge = value;
            }
        }

        public int IdSpellEffect { get; init; }
        public SpellEffect Effect { get; init; } = null!;

        public abstract float CalculateCastPrice();
    }
}
