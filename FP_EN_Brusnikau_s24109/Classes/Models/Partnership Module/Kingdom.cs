using System.Collections.Generic;
using System;
using System.Linq;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module
{
	public class Kingdom : Benefactor
	{
		private const int MinRulerNameLength = 5, MaxRulerNameLength = 120;

		private List<string> _successionOrder = new();
		public List<string> SuccessionOrder
		{
			get => new(_successionOrder);
			set
			{
				if (value.Count < 1)
				{
					throw new ArgumentException
					(
						"Kingdom must have at least one member in the succession order to be the current ruler."
					);
				}

				foreach (var successor in value)
				{
					if (successor.Length is < MinRulerNameLength or > MaxRulerNameLength)
					{
						throw new ArgumentException
						(
							$"The name of a house ruler must be between {MinRulerNameLength} and {MaxRulerNameLength} characters long."
						);
					}
				}

				_successionOrder = value;
			}
		}

		public string CurrentHead => _successionOrder[0];

		public string? NextSuccessor => _successionOrder[1];

		private List<NobleHouse> _nobleHouses = new();
		public List<NobleHouse> NobleHouses
		{
			get => new(_nobleHouses);
			init
			{
				if (value.Count != value.Distinct().Count())
				{
					throw new ArgumentException("There can't be duplicates in the list of noble houses.");
				}

				_nobleHouses = value;
			}
		}
	}
}
