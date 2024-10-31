using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class CircleSpell : BaseSpell
	{
		private const int MinCircleRadius = 5, MaxCircleRadius = 50;

		private int _circleRadius;
        public int CircleRadius 
		{ 
			get => _circleRadius; 
			init
			{
				if (value is < MinCircleRadius or > MaxCircleRadius) 
				{
					throw new ArgumentException
					(
						$"Spell's circle radius must be between {MinCircleRadius} and {MaxCircleRadius}."
					);
				}

				_circleRadius = value;
			}
		}

		public override float CalculateCastPrice()
		{
			return (float)(Math.PI * Math.Pow(_circleRadius, 2)) * Effect.Potency;
		}
	}
}
