using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class SpecialEffectEntityTypeConfiguration : IEntityTypeConfiguration<SpecialEffect>
	{
		public void Configure(EntityTypeBuilder<SpecialEffect> builder)
		{
			builder.ToTable("Special_Effects");
			
			builder.Property(p => p.EffectDesctiption).HasMaxLength(SpecialEffect.MaxDescriptionLength).IsRequired();
		}
	}
}
