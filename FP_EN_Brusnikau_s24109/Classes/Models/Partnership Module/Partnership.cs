using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module
{
	public class Partnership
	{
		public int IdPartnership { get; init; }

		private const int MinTitleLength = 5, MaxTitleLength = 120;

		private string _title = null!;
		public string Title
		{
			get => _title;
			init
			{
				if (value.Length is < MinTitleLength or > MaxTitleLength)
				{
					throw new ArgumentException
					(
						$"Partnership title length must be between {MinTitleLength} and {MaxTitleLength} characters."
					);
				}

				_title = value;
			}
		}

		public PartnershipGoal Goal { get; init; }

		private DateTime _partnershipStart = DateTime.Now;
		public DateTime PartnershipStart 
		{ 
			get => _partnershipStart;
		}

		private DateTime? _partnershipEnd = null;
		public DateTime? PartnershipEnd 
		{ 
			get => _partnershipEnd; 
			private set
			{
				if (_partnershipEnd <= _partnershipStart)
				{
					throw new ArgumentException
					(
						"Cannot set partnership end date before its' start."
					);
				}

				_status = PartnershipStatus.Concluded;
				_partnershipEnd = value;
			}
		}

		private PartnershipStatus _status = PartnershipStatus.Ongoing;
		public PartnershipStatus Status => _status;

		public float MonthlyContribution { get; init; }

		public int IdBenefactor { get; init; }
		public Benefactor Benefactor { get; init; } = null!;

		public int IdMage { get; init; }
		public Mage Mage { get; init; } = null!;

		public int GetLengthOfPartnershipInMonths()
		{
			return ((DateTime.Now.Year - _partnershipStart.Year) * 12) + DateTime.Now.Month - _partnershipStart.Month;
		}

		public float CalculateTotalContribution()
		{
			return GetLengthOfPartnershipInMonths() * MonthlyContribution;
		}

		public void ConcludePartnership()
		{
			PartnershipEnd = DateTime.Now;
		}
	}
}
