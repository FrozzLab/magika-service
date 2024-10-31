using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.School_Module
{
	public class TeachingSchoolDomainEntityTypeConfiguration : IEntityTypeConfiguration<TeachingSchoolDomain>
	{
		public void Configure(EntityTypeBuilder<TeachingSchoolDomain> builder)
		{
			builder.HasKey(k => new { k.IdArcaneSchool, k.IdArcaneDomain }).HasName("PK_Teaching_Schools_Domains");

			builder.ToTable("Teaching_Schools_Domains");

			builder.HasOne(tsd => tsd.ArcaneSchool)
				   .WithMany(asc => asc.TaughtDomains)
				   .HasForeignKey(e => e.IdArcaneSchool)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(tsd => tsd.ArcaneDomain)
				   .WithMany(ad => ad.TeachingSchools)
				   .HasForeignKey(e => e.IdArcaneDomain)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
