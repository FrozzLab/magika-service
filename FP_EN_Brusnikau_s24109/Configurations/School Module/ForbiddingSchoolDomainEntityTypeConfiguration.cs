using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.School_Module
{
	public class ForbiddingSchoolDomainEntityTypeConfiguration : IEntityTypeConfiguration<ForbiddingSchoolDomain>
	{
		public void Configure(EntityTypeBuilder<ForbiddingSchoolDomain> builder)
		{
			builder.HasKey(k => new { k.IdArcaneSchool, k.IdArcaneDomain }).HasName("PK_Forbidding_Schools_Domains");

			builder.ToTable("Forbidding_Schools_Domains");

			builder.HasOne(fsd => fsd.ArcaneSchool)
				   .WithMany(asc => asc.ForbiddenDomains)
				   .HasForeignKey(e => e.IdArcaneSchool)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired(false);

			builder.HasOne(fsd => fsd.ArcaneDomain)
				   .WithMany(ad => ad.ForbiddingSchools)
				   .HasForeignKey(e => e.IdArcaneDomain)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired(false);
		}
	}
}
