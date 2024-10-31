using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class BaseSpellEntityTypeConfiguration : IEntityTypeConfiguration<BaseSpell>
	{
		public void Configure(EntityTypeBuilder<BaseSpell> builder)
		{
			builder.HasKey(k => k.IdSpell).HasName("PK_Spells");

			builder.UseTptMappingStrategy().ToTable("Spells");

			builder.HasIndex(i => i.Name).IsUnique();
			
			builder.Property(p => p.PowerLevelCost).IsRequired();


			builder.HasMany(m => m.MagesKnowledge)
				   .WithOne(ms => ms.Spell)
				   .HasForeignKey(ms => ms.IdSpell)
				   .IsRequired();

			builder.HasOne(s => s.ArcaneDomain)
				   .WithMany(ad => ad.Spells)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(se => se.Effect)
				   .WithOne(s => s.Spell)
				   .HasForeignKey<SpellEffect>(se => se.IdSpellEffect)
				   .IsRequired();
		}
	}
}
