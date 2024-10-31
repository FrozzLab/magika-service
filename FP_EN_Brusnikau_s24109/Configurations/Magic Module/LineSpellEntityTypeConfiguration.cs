using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class LineSpellEntityTypeConfiguration : IEntityTypeConfiguration<LineSpell>
	{
		public void Configure(EntityTypeBuilder<LineSpell> builder)
		{
			builder.ToTable("Line_Spells");

			builder.Property(p => p.LineLength).IsRequired();
			builder.Property(p => p.LineWidth).IsRequired();
		}
	}
}
