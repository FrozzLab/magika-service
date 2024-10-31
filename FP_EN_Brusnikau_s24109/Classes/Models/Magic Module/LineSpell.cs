using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class LineSpell : BaseSpell
	{
		private const int MinLineLength = 10, MaxLineLength = 250;

		private int _lineLength;
        public int LineLength 
		{ 
			get => _lineLength; 
			init
			{
				if (value is < MinLineLength or > MaxLineLength) 
				{
					throw new ArgumentException
					(
						$"Spell's line length must be between {MinLineLength} and {MaxLineLength}."
					);
				}

				_lineLength = value;
			}
		}

		private const int MinLineWidth = 1, MaxLineWidth = 5;

		private int _lineWidth;
		public int LineWidth
		{
			get => _lineWidth;
			init
			{
				if (value is < MinLineWidth or > MaxLineWidth)
				{
					throw new ArgumentException
					(
						$"Spell's line width must be between {MinLineWidth} and {MaxLineWidth}."
					);
				}

				_lineWidth = value;
			}
		}

		public override float CalculateCastPrice()
		{
			return LineLength * LineWidth * Effect.Potency;
		}
	}
}
