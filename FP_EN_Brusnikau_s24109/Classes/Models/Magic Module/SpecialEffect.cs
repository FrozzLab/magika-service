using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class SpecialEffect : SpellEffect
	{
		public const int MinDescriptionLength = 5, MaxDescriptionLength = 120;

		private string _effectDescription = null!;
		public string EffectDesctiption
		{
			get => _effectDescription;
			init
			{
				if (value.Length is < MinDescriptionLength or > MaxDescriptionLength)
				{
					throw new ArgumentException
					(
						$"Spell effect description length must be between {MinDescriptionLength} and {MaxDescriptionLength} characters."
					);
				}

				_effectDescription = value;
			}
		}
	}
}
