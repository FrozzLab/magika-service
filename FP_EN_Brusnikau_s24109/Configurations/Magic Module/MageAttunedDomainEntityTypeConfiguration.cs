using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class MageAttunedDomainEntityTypeConfiguration : IEntityTypeConfiguration<MageAttunedDomain>
	{
		public void Configure(EntityTypeBuilder<MageAttunedDomain> builder)
		{
			builder.HasKey(k => new { k.IdMage, k.IdArcaneDomain }).HasName("PK_Mages_Attuned_Domains");

			builder.ToTable("Mages_Attuned_Domains");

			builder.HasOne(e => e.Mage)
				   .WithMany(m => m.AttunedDomains)
				   .HasForeignKey(e => e.IdMage)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(e => e.ArcaneDomain)
				   .WithMany(ad => ad.AttunedMages)
				   .HasForeignKey(e => e.IdArcaneDomain)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
