using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class ProjectileSpellEntityTypeConfiguration : IEntityTypeConfiguration<ProjectileSpell>
	{
		public void Configure(EntityTypeBuilder<ProjectileSpell> builder)
		{
			builder.ToTable("Projectile_Spells");

			builder.Property(p => p.ProjectileCount).IsRequired();
			builder.Property(p => p.ProjectilePower).IsRequired();
		}
	}
}
