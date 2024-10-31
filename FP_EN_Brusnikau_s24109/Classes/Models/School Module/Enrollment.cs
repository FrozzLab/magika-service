using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using System;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.School_Module
{
	public class Enrollment
	{
		public int IdEnrollment { get; init; }

		private DegreeType _degreeType;
        public DegreeType DegreeType 
		{ 
			get => _degreeType;
			init
			{
				if (!ArcaneSchool.EnrollmentLengthByDegree.ContainsKey(value))
				{
					throw new ArgumentException
					(
						"Enrollment cannot be created as the provided school does not accomodate given degree type."
					);
				}

				_degreeType = value;
			}
		}

		private DateTime _admissionDate = DateTime.Now;
		public DateTime AdmissionDate
		{
			get => _admissionDate;
		}

		private DateTime? _graduationDate = null;
		public DateTime? GraduationDate
		{
			get => _graduationDate;
			private set
			{
				if (value == null)
				{
					_graduationDate = value;

					return;
				}

				if (_explusionDate != null)
				{
					throw new ArgumentException
					(
						"Cannot set graduation date for enrollmnent as the mage has already been expelled."
					);
				}

				if (value - _admissionDate < ArcaneSchool.EnrollmentLengthByDegree.Single(asc => asc.Key == DegreeType).Value)
				{
					throw new ArgumentException
					(
						$"Enrollment graduation date must be at least {ArcaneSchool.EnrollmentLengthByDegree.Single(asc => asc.Key == DegreeType).Value}."
					);
				}

				_graduationDate = value;
			}
		}

		private DateTime? _explusionDate = null;
		public DateTime? ExpulsionDate 
		{ 
			get => _explusionDate;
			private set
			{
				if (_graduationDate != null)
				{
					throw new ArgumentException
					(
						"Cannot set expulsion date for enrollment as the mage has already graduated."
					);
				}

				if (value <= _admissionDate)
				{
					throw new ArgumentException
					(
						"Cannot set expulsion date for enrollment to before the mage's admission."
					);
				}

				_explusionDate = value;
			}
		}

		public EnrollmentStatus EnrollmentStatus 
		{
			get
			{
				if (GraduationDate != null)
				{
					return EnrollmentStatus.Graduated;
				}

				if (ExpulsionDate != null)
				{
					return EnrollmentStatus.Expelled;
				}

				return EnrollmentStatus.Ongoing;
			}
		}

		public int IdArcaneSchool { get; init; }
		public ArcaneSchool ArcaneSchool { get; init; } = null!;

		public int IdMage { get; init; }
		public Mage Mage { get; init; } = null!;

		public void Expel()
		{
			if (EnrollmentStatus != EnrollmentStatus.Ongoing)
			{
				throw new ArgumentException
				(
					"Cannot expel student as the enrollment is already concluded."
				);
			}

			ExpulsionDate = DateTime.Now;
		}

		public void Graduate()
		{
			if (EnrollmentStatus != EnrollmentStatus.Ongoing)
			{
				throw new ArgumentException
				(
					"Cannot graduate student as the enrollment is already concluded."
				);
			}

			GraduationDate = DateTime.Now;
		}
	}
}
