using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class SpellKnowledgeEntityTypeConfiguration : IEntityTypeConfiguration<SpellKnowledge>
	{
		public void Configure(EntityTypeBuilder<SpellKnowledge> builder)
		{
			builder.HasKey(k => new {k.IdMage, k.IdSpell }).HasName("PK_Spells_Knowledge");

			builder.ToTable("Spells_Knowledge");

			builder.Property(sk => sk.LearningDate).IsRequired();
			builder.Property(sk => sk.LevelOfUnderstanding).IsRequired();

			builder.HasOne(sk => sk.Mage)
				   .WithMany(m => m.SpellsKnowledge)
				   .HasForeignKey(sk => sk.IdMage)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(sk => sk.Spell)
				   .WithMany(s => s.MagesKnowledge)
				   .HasForeignKey(sk => sk.IdSpell)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
