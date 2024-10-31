using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.School_Module
{
	public class EnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrollment>
	{
		public void Configure(EntityTypeBuilder<Enrollment> builder)
		{
			builder.HasKey(k => k.IdEnrollment).HasName("PK_Enrollments");

			builder.ToTable("Enrollments");

			builder.Property(p => p.DegreeType).IsRequired();
			builder.Property(p => p.AdmissionDate).IsRequired();
			builder.Property(p => p.GraduationDate);
			builder.Property(p => p.ExpulsionDate);

			builder.HasOne(e => e.Mage)
				   .WithMany(m => m.Enrollments)
				   .HasForeignKey(e => e.IdMage)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(e => e.ArcaneSchool)
				   .WithMany(asc => asc.Enrollments)
				   .HasForeignKey(e => e.IdArcaneSchool)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
