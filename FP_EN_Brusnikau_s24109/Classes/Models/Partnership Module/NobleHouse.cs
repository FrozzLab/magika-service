using System;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module
{
	public class NobleHouse : Benefactor
	{
		public HouseType HouseType { get; init; }

		private const int MinRulerNameLength = 5, MaxRulerNameLength = 120, MinRulerCount = 3;

		private List<string> _boardOfRulers = new();
        public List<string> BoardOfRulers 
		{ 
			get => new(_boardOfRulers); 
			set
			{
				if (value.Count < MinRulerCount)
				{
					throw new ArgumentException
					(
						$"The board of rulers must contain at least {MinRulerCount} members."
					);
				}

				foreach ( var ruler in value ) 
				{
					if (ruler.Length is < MinRulerNameLength or > MaxRulerNameLength)
					{
						throw new ArgumentException
						(
							$"The name of a house ruler must be between {MinRulerNameLength} and {MaxRulerNameLength} characters long."
						);
					}
				}

				_boardOfRulers = value;
			}
		}

		public int IdKingdom { get; init; }
		public Kingdom Kingdom { get; init; } = null!;
	}
}
