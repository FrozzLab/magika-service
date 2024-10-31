using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Core_Module
{
    public class MageEntityTypeConfiguration : IEntityTypeConfiguration<Mage>
    {
        public void Configure(EntityTypeBuilder<Mage> builder)
        {
			builder.HasKey(k => k.IdMage).HasName("PK_Mages");

			builder.ToTable("Mages");

			builder.Property(p => p.Name).HasMaxLength(Mage.MaxNameLength).IsRequired();
            builder.Property(p => p.TotalPowerLevel).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();

            builder.HasMany(m => m.SpellsKnowledge)
                   .WithOne(sk => sk.Mage)
                   .HasForeignKey(sk => sk.IdMage)
                   .IsRequired();

            builder.HasMany(m => m.Partnerships)
                   .WithOne(p => p.Mage)
                   .HasForeignKey(p => p.IdMage)
                   .IsRequired();

            builder.HasMany(m => m.Applications)
                   .WithOne(a => a.Mage)
                   .HasForeignKey(a => a.IdMage)
                   .IsRequired();

            builder.HasMany(m => m.Enrollments)
                   .WithOne(e => e.Mage)
                   .HasForeignKey(e => e.IdMage)
                   .IsRequired();

            builder.HasMany(m => m.AttunedDomains)
                   .WithOne(mad => mad.Mage)
                   .HasForeignKey(mad => mad.IdMage)
                   .IsRequired();

            builder.HasOne(m => m.SoulBoundDomain)
                   .WithMany(ad => ad.SoulBoundMages)
                   .HasForeignKey(m => m.IdSoulBoundDomain)
                   .IsRequired(false);
        }
    }
}
