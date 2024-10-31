using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class ConeSpell : BaseSpell
	{
		private const int MinConeSlantHeight = 10, MaxConeSlantHeight = 100;

		private int _coneSlantHeight;
        public int ConeSlantHeight 
		{ 
			get => _coneSlantHeight; 
			init
			{
				if (value is < MinConeSlantHeight or > MaxConeSlantHeight) 
				{
					throw new ArgumentException
					(
						$"Spell's cone slant height must be between {MinConeSlantHeight} and {MaxConeSlantHeight}."
					);
				}

				_coneSlantHeight = value;
			}
		}

		private const int MinConeRadius = 3, MaxConeRadius = 25;

		private int _coneRadius;
		public int ConeRadius
		{
			get => _coneRadius;
			init
			{
				if (value is < MinConeRadius or > MaxConeRadius)
				{
					throw new ArgumentException
					(
						$"Spell's cone radius must be between {MinConeRadius} and {MaxConeRadius}."
					);
				}

				_coneRadius = value;
			}
		}

		public override float CalculateCastPrice()
		{
			return (float)(Math.PI * Math.Pow(_coneRadius, 2) + Math.PI * ConeRadius * ConeSlantHeight) * Effect.Potency;
		}
	}
}
