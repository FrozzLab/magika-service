using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class DamagingEffectEntityTypeConfiguration : IEntityTypeConfiguration<DamagingEffect>
	{
		public void Configure(EntityTypeBuilder<DamagingEffect> builder)
		{
			builder.ToTable("Damaging_Effects");
			
			builder.Property(p => p.DamageTarget).IsRequired();
		}
	}
}
