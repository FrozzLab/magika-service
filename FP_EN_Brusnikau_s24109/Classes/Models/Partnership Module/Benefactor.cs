using System;
using System.Collections.Generic;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module
{
	public abstract class Benefactor
    {
        public int IdBenefactor { get; init; }

        private const int MinNameLength = 5, MaxNameLength = 120;

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

		private static readonly DateTime MinEstablishmentDate = new(500, 1, 1);

		private DateTime _establishmentDate;
		public DateTime EstablishmentDate
		{
			get => _establishmentDate;
			init
			{
				if (value < MinEstablishmentDate || value > DateTime.Now)
				{
					throw new ArgumentException
					(
						$"Benefactor establishment date must be between {MinEstablishmentDate} and {DateTime.Now}."
					);
				}

				_establishmentDate = value;
			}
		}

		private List<Application> _applications = new();
		public virtual ICollection<Application> Applications
		{
			get => new List<Application>(_applications);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException("There can't be duplicates in the list of partnership applications.");
				}

				_applications = new List<Application>(value);
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
					throw new ArgumentException("There can't be duplicates in the list of partnerships.");
				}

				_partnerships = value;
			}
		}
	}
}
