using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
    public class ArcaneDomainEntityTypeConfiguration : IEntityTypeConfiguration<ArcaneDomain>
	{
		public void Configure(EntityTypeBuilder<ArcaneDomain> builder)
		{
			builder.HasKey(k => k.IdArcaneDomain).HasName("PK_Arcane_Domains");

			builder.ToTable("Arcane_Domains");

			builder.Property(p => p.Name).HasMaxLength(ArcaneDomain.MaxNameLength).IsRequired();
			builder.Property(p => p.AuraType).IsRequired();

			builder.HasMany(ad => ad.Spells)
				   .WithOne(s => s.ArcaneDomain)
				   .HasForeignKey(ad => ad.IdArcaneDomain)
				   .IsRequired();

			builder.HasMany(ad => ad.SoulBoundMages)
				   .WithOne(m => m.SoulBoundDomain)
				   .HasForeignKey(m => m.IdSoulBoundDomain)
				   .IsRequired(false);

			builder.HasMany(ad => ad.AttunedMages)
				   .WithOne(mad => mad.ArcaneDomain)
				   .HasForeignKey(mad => mad.IdArcaneDomain)
				   .IsRequired();

			builder.HasMany(ad => ad.TeachingSchools)
				   .WithOne(tsd => tsd.ArcaneDomain)
				   .HasForeignKey(tsd => tsd.IdArcaneDomain)
				   .IsRequired();

			builder.HasMany(ad => ad.ForbiddingSchools)
				   .WithOne(fsd => fsd.ArcaneDomain)
				   .HasForeignKey(fsd => fsd.IdArcaneDomain)
				   .IsRequired(false);
		}
	}
}
