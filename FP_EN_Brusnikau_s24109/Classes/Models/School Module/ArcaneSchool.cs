using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.School_Module
{
	public class ArcaneSchool
	{
		public int IdArcaneSchool { get; init; }

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
						$"Arcane school name length must be between {MinNameLength} and {MaxNameLength} characters."
					);
				}

				_name = value;
			}
		}

		private static readonly TimeSpan MinDegreeLength = new(720, 0, 0, 0), MaxDegreeLength = new(3650, 0, 0, 0);

		private Dictionary<DegreeType, TimeSpan> _enrollmentLengthByDegree = new();
        public Dictionary<DegreeType, TimeSpan> EnrollmentLengthByDegree
		{ 
			get => new(_enrollmentLengthByDegree); 
			set
			{
				foreach (var kvp in _enrollmentLengthByDegree)
				{
					if (kvp.Value < MinDegreeLength || kvp.Value > MaxDegreeLength)
					{
						throw new ArgumentException
						(
							$"Degree completion length must be between {MinDegreeLength} and {MaxDegreeLength}."
						);
					}
				}

				_enrollmentLengthByDegree = value;
			}
		}

		private static readonly DateTime MinFoundationDate = new(500, 1, 1);

		private DateTime _foundationDate;
		public DateTime FoundationDate
		{
			get => _foundationDate;
			init
			{
				if (value < MinFoundationDate || value > DateTime.Now)
				{
					throw new ArgumentException
					(
						$"School foundation date must be between {MinFoundationDate} and {DateTime.Now}."
					);
				}

				_foundationDate = value;
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

		private List<TeachingSchoolDomain> _taughtDomains = new();
		public List<TeachingSchoolDomain> TaughtDomains
		{
			get => new(_taughtDomains);
			init
			{
				if (value.Count < 1)
				{
					throw new ArgumentException
					(
						"There must be at least one domain taught at the school."
					);
				}

				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of taught domains."
					);
				}

				if (_forbiddenDomains.Select(fsd => fsd.ArcaneDomain).Intersect(value.Select(tsd => tsd.ArcaneDomain)).Count() != 0)
				{
					throw new ArgumentException
					(
						"Cannot set list of taught domains as some of its' values are present in the list of forbidden domains."
					);
				}

				_taughtDomains = value;
			}
		}

		private List<ForbiddingSchoolDomain> _forbiddenDomains = new();
		public List<ForbiddingSchoolDomain> ForbiddenDomains
		{
			get => new(_forbiddenDomains);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException
					(
						"There can't be duplicates in the list of forbidden domains."
					);
				}

				if (_taughtDomains.Select(tsd => tsd.ArcaneDomain).Intersect(value.Select(fsd => fsd.ArcaneDomain)).Count() != 0)
				{
					throw new ArgumentException
					(
						"Cannot set list of forbidden domains as some of its' values are present in the list of taught domains."
					);
				}

				_forbiddenDomains = value;
			}
		}

		public Enrollment EnrollMage(Mage applicant, DegreeType degreeType)
		{
			if (Enrollments.Any(e => e.Mage == applicant && e.ArcaneSchool == this && e.DegreeType == degreeType))
			{
				throw new ArgumentException
				(
					"Cannot enroll mage as they have already completed this degree at the school."
				);
			}

			if (Enrollments.Any(e => e.Mage == applicant && e.ArcaneSchool == this && e.GraduationDate == null))
			{
				throw new ArgumentException
				(
					"Cannot enroll mage as they are already undergoing a degree at the school."
				);
			}

			var enrollment = new Enrollment
			{
				ArcaneSchool = this,
				Mage = applicant,
				DegreeType = degreeType
			};

			Enrollments.Add(enrollment);

			return enrollment;
		}

		public void GraduateMage(Mage student)
		{
			var enrollment = Enrollments.SingleOrDefault(e => e.Mage == student 
				&& e.ArcaneSchool == this && e.EnrollmentStatus == EnrollmentStatus.Ongoing);

			if (enrollment == null)
			{
				throw new ArgumentException
				(
					"Cannot graduate mage as they are not a student at the school."
				);
			}

			enrollment.Graduate();
		}

		public void ExpelMage(Mage student)
		{
			var enrollment = Enrollments.SingleOrDefault(e => e.Mage == student 
				&& e.ArcaneSchool == this && e.EnrollmentStatus == EnrollmentStatus.Ongoing);

			if (enrollment == null)
			{
				throw new ArgumentException
				(
					"Cannot expel mage as they are not a student at the school."
				);
			}

			enrollment.Expel();
		}

		public TeachingSchoolDomain AddTaughtDomain(ArcaneDomain domain)
		{
			if (_forbiddenDomains.Select(fsd => fsd.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot add taught domain as it's already forbidden at the school."
				);
			}

			if (_taughtDomains.Select(tsd => tsd.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot add taught domain as it's already taught at the school."
				);
			}

			var tsd = new TeachingSchoolDomain
			{
				ArcaneSchool = this,
				ArcaneDomain = domain
			};

			_taughtDomains.Add(tsd);

			return tsd;
		}

		public TeachingSchoolDomain RemoveTaughtDomain(ArcaneDomain domain)
		{
			if (!_taughtDomains.Select(tsd => tsd.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot remove taught domain as it's already not taught at the school."
				);
			}

			var tsd = _taughtDomains.Single(tsd => tsd.ArcaneDomain == domain);

			_taughtDomains.Remove(tsd);

			return tsd;
		}

		public ForbiddingSchoolDomain AddForbiddenDomain(ArcaneDomain domain)
		{
			if (_taughtDomains.Select(tsd => tsd.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot add forbidden domain as it's already taught at the school."
				);
			}

			if (_forbiddenDomains.Select(fsd => fsd.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot add forbidden domain as it's already forbidden at the school."
				);
			}

			var fsd = new ForbiddingSchoolDomain
			{
				ArcaneSchool = this,
				ArcaneDomain = domain
			};

			_forbiddenDomains.Add(fsd);

			return fsd;
		}

		public ForbiddingSchoolDomain RemoveForbiddenDomain(ArcaneDomain domain)
		{
			if (!_forbiddenDomains.Select(fsd => fsd.ArcaneDomain).Contains(domain))
			{
				throw new ArgumentException
				(
					"Cannot remove forbidden domain as it's already not forbidden at the school."
				);
			}

			var fsd = _forbiddenDomains.Single(fsd => fsd.ArcaneDomain == domain);

			_forbiddenDomains.Remove(fsd);

			return fsd;
		}
	}
}
