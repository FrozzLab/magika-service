using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class SpellEffectEntityTypeConfiguration : IEntityTypeConfiguration<SpellEffect>
	{
		public void Configure(EntityTypeBuilder<SpellEffect> builder)
		{
			builder.HasKey(k => k.IdSpellEffect).HasName("PK_Spell_Effects");

			builder.UseTptMappingStrategy().ToTable("Spell_Effects");
			
			builder.Property(p => p.EffectType).IsRequired();
			builder.Property(p => p.ImmuneCreatures)
				.HasConversion
				   (
					   ic => JsonConvert.SerializeObject(ic),
					   ic => JsonConvert.DeserializeObject<List<CreatureType>>(ic) ?? new List<CreatureType>(),
					   new ValueComparer<List<CreatureType>>(
					   (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
					   c => c != null ? JsonConvert.SerializeObject(c).GetHashCode() : 0,
					   c => JsonConvert.DeserializeObject<List<CreatureType>>(JsonConvert.SerializeObject(c))
							?? new List<CreatureType>())
				   )
				.IsRequired();
			builder.Property(p => p.Potency).IsRequired();

			builder.HasOne(se => se.Spell)
				   .WithOne(s => s.Effect)
				   .HasForeignKey<BaseSpell>(se => se.IdSpell)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
