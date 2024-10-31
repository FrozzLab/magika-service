using FP_EN_Brusnikau_s24109.Classes.DTOs.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using Application = FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module.Application;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Core_Module
{
	public class Mage
	{
		public int IdMage { get; init; }

		public const int MinNameLength = 1, MaxNameLength = 120;

		private string _name = null!;
        public string Name 
		{ 
			get => _name; 
			set
			{
				if (value.Length is < MinNameLength or > MaxNameLength)
				{
					throw new ArgumentException
					(
						$"Mage name length must be between {MinNameLength} and {MaxNameLength} characters."
					);
				}
				
				if (value.IndexOfAny("0123456789".ToCharArray()) != -1)
				{
					throw new ArgumentException
					(
						"Mage name cannot contain digits."
					);
				}

				_name = value;
			}
		}

        private const int MinPowerLevel = 1, MaxPowerLevel = 10000;

		private int _totalPowerLevel;
        public int TotalPowerLevel 
		{ 
			get => _totalPowerLevel; 
			set
			{
                if (value is < MinPowerLevel or > MaxPowerLevel)
                {
					throw new ArgumentException
					(
						$"Total power level must be between {MinPowerLevel} and {MaxPowerLevel}."
					);
                }

				if (value - _spellsKnowledge.Sum(sk => sk.CostOfKnowledge) < 0)
				{
					throw new ArgumentException
					(
						$"Cannot set total power level to {value} as it's not enough to support currently known spells."
					);
				}

				_totalPowerLevel = value;
            }
		}

		public int currentPowerLevel => _totalPowerLevel - _spellsKnowledge.Sum(sk => sk.CostOfKnowledge);

		private readonly static TimeSpan MinAge = new(4383, 0, 0, 0); // 12 years with 365,25 leap year approximation 

		private DateTime _birthDate;
        public DateTime BirthDate 
		{ 
			get => _birthDate;
			init
			{
				if (DateTime.Now < (value + MinAge))
				{
					throw new ArgumentException
					(
						"A mage must be at least 12 years old."
					);
				}

				_birthDate = value;
			}
		}

		private List<SpellKnowledge> _spellsKnowledge = new();
		public virtual ICollection<SpellKnowledge> SpellsKnowledge
		{
			get => new List<SpellKnowledge>(_spellsKnowledge);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of spells."
					);
				}

				_spellsKnowledge = new List<SpellKnowledge>(value);
			}
		}

		private List<MageAttunedDomain> _attunedDomains = new();
		public List<MageAttunedDomain> AttunedDomains
		{
			get => new(_attunedDomains);
			init
			{
				if (value.Count < 1)
				{
					throw new ArgumentException
					(
						"Mage must have at least one attuned domain."
					);
				}

				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of attuned domains."
					);
				}

				_attunedDomains = value;
			}
		}
		
		public int? IdSoulBoundDomain { get; set; }
		private ArcaneDomain? _soulBoundDomain = null;
		public ArcaneDomain? SoulBoundDomain
		{
			get => _soulBoundDomain;
			set
			{
				if (value == null)
				{
					_soulBoundDomain = null;

					return;
				}

				if (!_attunedDomains.Select(mad => mad.ArcaneDomain).Contains(value))
				{
					throw new ArgumentException
					(
						"Cannot soul-bind domain as the mage is not attuned to it."
					);
				}

				_soulBoundDomain = value;
			}
		}

		private List<Application> _applications = new();
		public List<Application> Applications
		{
			get => new(_applications);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of partnership applications."
					);
				}

				_applications = value;
			}
		}

		private List<Partnership> _partnerships = new();
		public List<Partnership> Partnerships
		{
			get => new(_partnerships);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of partnerships."
					);
				}

				_partnerships = value;
			}
		}

		private List<Enrollment> _enrollments = new();
		public List<Enrollment> Enrollments
		{
			get => new(_enrollments);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of enrollments."
					);
				}

				_enrollments = value;
			}
		}

		public void AddAttunedDomain(ArcaneDomain domain)
		{
			if (_attunedDomains.Select(mad => mad.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot add attuned domain as the mage is already attuned to it."
				);
			}

			var mad = new MageAttunedDomain
			{
				Mage = this,
				ArcaneDomain = domain
			};

			_attunedDomains.Add(mad);
		}

		public void RemoveAttunedDomain(ArcaneDomain domain)
		{
			if (!_attunedDomains.Select(mad => mad.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot remove attuned domain as the mage is already not attuned to it."
				);
			}

			var mad = _attunedDomains.Single(mad => mad.ArcaneDomain == domain);

			_attunedDomains.Remove(mad);
		}

		public Application SendOutApplicationForPartnership(ApplicationDTO applicationDTO)
		{
			if (applicationDTO.Mage != this)
			{
				throw new ArgumentException
				(
					"Cannot send out application as provided mage is different from the mage method was called on."
				);
			}

			var application = new Application
			{
				Mage = applicationDTO.Mage,
				Benefactor = applicationDTO.Benefactor,
				Title = applicationDTO.Title,
				Goal = applicationDTO.Goal,
				Description = applicationDTO.Description
			};

			application.MakeOffer(applicationDTO.InitialOffer, OfferingSide.Applicant);

			return application;
		}
	}
}
