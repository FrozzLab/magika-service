using System;
using System.Collections.Generic;
using System.Linq;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class ArcaneDomain
    {
        public int IdArcaneDomain { get; init; }

        public const int MaxNameLength = 120;

        private string _name = null!;
        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Arcane domain name cannot be empty or null");
                }

                if (value.Length > MaxNameLength)
                {
                    throw new ArgumentException
                    (
                        $"Arcane domain name length cannot exceed {MaxNameLength} symbols."
                    );
                }

                _name = value;
            }
        }

        public AuraType AuraType { get; init; }

        private List<BaseSpell> _spells = new();
        public List<BaseSpell> Spells
        {
            get => new(_spells);
            init
            {
                if (value.Count != value.Distinct().Count())
                {
                    throw new ArgumentException("There can't be duplicates in the list of spells.");
                }

                _spells = value;
            }
        }

		private List<MageAttunedDomain> _attunedMages = new();
		public List<MageAttunedDomain> AttunedMages
		{
			get => new(_attunedMages);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException("There can't be duplicates in the list of attuned mages.");
				}

				_attunedMages = value;
			}
		}

		private List<Mage> _soulBoundMages = new();
		public List<Mage> SoulBoundMages
		{
			get => new(_soulBoundMages);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException("There can't be duplicates in the list of soul-bound mages.");
				}

				_soulBoundMages = value;
			}
		}

		private List<TeachingSchoolDomain> _teachingSchools = new();
		public List<TeachingSchoolDomain> TeachingSchools
		{
			get => new(_teachingSchools);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException("There can't be duplicates in the list of teaching schools.");
				}

				if (_forbiddingSchools.Select(fsd => fsd.ArcaneDomain).Intersect(value.Select(tsd => tsd.ArcaneDomain)).Count() != 0)
				{
					throw new ArgumentException
					(
						"Cannot set list of teaching schools as some of its' values are present in the list of forbidding schools."
					);
				}

				_teachingSchools = value;
			}
		}

		private List<ForbiddingSchoolDomain> _forbiddingSchools = new();
		public List<ForbiddingSchoolDomain> ForbiddingSchools
		{
			get => new(_forbiddingSchools);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException("There can't be duplicates in the list of forbidding schools.");
				}

				if (_teachingSchools.Select(tsd => tsd.ArcaneDomain).Intersect(value.Select(fsd => fsd.ArcaneDomain)).Count() != 0)
				{
					throw new ArgumentException
					(
						"Cannot set list of forbidding schools as some of its' values are present in the list of teaching schools."
					);
				}

				_forbiddingSchools = value;
			}
		}
	}
}
