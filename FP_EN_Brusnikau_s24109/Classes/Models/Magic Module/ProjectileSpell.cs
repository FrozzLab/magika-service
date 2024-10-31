using System;

namespace FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module
{
	public class ProjectileSpell : BaseSpell
	{
		private const int MinProjectileCount = 1, MaxProjectileCount = 250;

		private int _projectileCount;
        public int ProjectileCount 
		{ 
			get => _projectileCount; 
			init
			{
				if (value is < MinProjectileCount or > MaxProjectileCount) 
				{
					throw new ArgumentException
					(
						$"Spell's projectile count must be between {MinProjectileCount} and {MaxProjectileCount}."
					);
				}

				_projectileCount = value;
			}
		}

		private const float MinProjectilePower = 0.5f, MaxProjectilePower = 5;

		private float _projectilePower;
		public float ProjectilePower
		{
			get => _projectilePower;
			init
			{
				if (value is < MinProjectilePower or > MaxProjectilePower)
				{
					throw new ArgumentException
					(
						$"Spell's projectile power must be between {MinProjectilePower} and {MaxProjectilePower}."
					);
				}

				_projectilePower = value;
			}
		}

		public override float CalculateCastPrice()
		{
			return ProjectileCount * ProjectilePower * Effect.Potency;
		}
	}
}
