using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class CircleSpellEntityTypeConfiguration : IEntityTypeConfiguration<CircleSpell>
	{
		public void Configure(EntityTypeBuilder<CircleSpell> builder)
		{
			builder.ToTable("Circle_Spells");

			builder.Property(p => p.CircleRadius).IsRequired();
		}
	}
}
