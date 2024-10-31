using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using System;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module
{
	public class Application
	{
		public int IdApplication { get; init; }

		public const int MinTitleLength = 5, MaxTitleLength = 120;

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
						$"Application title length must be between {MinTitleLength} and {MaxTitleLength} characters."
					);
				}

				_title = value;
			}
		}

        public PartnershipGoal Goal { get; init; }

		public const int MinDescriptionLength = 0, MaxDescriptionLength = 2000;

		private string _description = null!;
		public string Description
		{
			get => _description;
			init
			{
				if (value.Length is < MinDescriptionLength or > MaxDescriptionLength)
				{
					throw new ArgumentException
					(
						$"Application title length must be between {MinDescriptionLength} and {MaxDescriptionLength} characters."
					);
				}

				_description = value;
			}
		}

		private const int MinimumContribution = 25;

		private List<Offer> _offerHistory = new();
		public List<Offer> OfferHistory => new(_offerHistory);

		private OfferingSide _nextToRespond = OfferingSide.Applicant;
		public OfferingSide NextToRespond 
		{ 
			get => _nextToRespond;
			private set
			{
				_nextToRespond = value;
			}
		}

		private ApplicationStatus _status = ApplicationStatus.Ongoing;
		public ApplicationStatus Status => _status;

		public int IdBenefactor { get; init; }
		public Benefactor Benefactor { get; init; } = null!;

		public int IdMage { get; init; }
		public Mage Mage { get; init; } = null!;

		public void CancelNegotiations()
		{
			if (_status != ApplicationStatus.Ongoing)
			{
				throw new ArgumentException
				(
					"Cannot cancel negotiations as they are no longer ongoing."
				);
			}

			_status = ApplicationStatus.Cancelled;
		}

		public Partnership ConcludeNegotiations()
		{
			if (_status != ApplicationStatus.Ongoing)
			{
				throw new ArgumentException
				(
					"Cannot conclude negotiations as they are no longer ongoing."
				);
			}

			var partnership = new Partnership
			{
				Benefactor = Benefactor,
				Mage = Mage,
				Title = Title,
				Goal = Goal,
				MonthlyContribution = _offerHistory[^1].OfferValue
			};

			_status = ApplicationStatus.Concluded;

			return partnership;
		}

		public void MakeOffer(float offerValue, OfferingSide side)
		{
			if (_status != ApplicationStatus.Ongoing)
			{
				throw new ArgumentException
				(
					"Cannot make an offer as the application is no longer ongoing."
				);
			}

			if (side != NextToRespond)
			{
				throw new ArgumentException
				(
					"Can't make offer as the same side cannot make two offers in a row."
				);
			}

			if (offerValue < MinimumContribution)
			{
				throw new ArgumentException
				(
					$"Offer value cannot be less than {MinimumContribution}."
				);
			}

			_offerHistory.Add
			(
				new Offer
				{
					OfferingSide = side,
					OfferValue = offerValue
				}
			);

			if (side == OfferingSide.Applicant)
			{
				NextToRespond = OfferingSide.Benefactor;
			}
			else
			{
				NextToRespond = OfferingSide.Applicant;
			}
		}
    }
}
