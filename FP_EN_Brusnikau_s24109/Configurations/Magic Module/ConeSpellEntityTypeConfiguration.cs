using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class ConeSpellEntityTypeConfiguration : IEntityTypeConfiguration<ConeSpell>
	{
		public void Configure(EntityTypeBuilder<ConeSpell> builder)
		{
			builder.ToTable("Cone_Spells");

			builder.Property(p => p.ConeSlantHeight).IsRequired();
			builder.Property(p => p.ConeRadius).IsRequired();
		}
	}
}
