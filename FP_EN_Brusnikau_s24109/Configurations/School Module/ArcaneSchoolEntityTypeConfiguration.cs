using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Configurations.School_Module
{
	public class ArcaneSchoolEntityTypeConfiguration : IEntityTypeConfiguration<ArcaneSchool>
	{
		public void Configure(EntityTypeBuilder<ArcaneSchool> builder)
		{
			builder.HasKey(k => k.IdArcaneSchool).HasName("PK_Arcane_Schools");

			builder.ToTable("Arcane_Schools");

			builder.Property(p => p.Name).HasMaxLength(ArcaneSchool.MaxNameLength).IsRequired();
			builder.Property(p => p.EnrollmentLengthByDegree)
				   .HasConversion
				   (
					   eld => JsonConvert.SerializeObject(eld),
					   eld => JsonConvert.DeserializeObject<Dictionary<DegreeType, TimeSpan>>(eld) ?? new Dictionary<DegreeType, TimeSpan>(),
					   new ValueComparer<Dictionary<DegreeType, TimeSpan>>(
					   (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
					   c => c != null ? JsonConvert.SerializeObject(c).GetHashCode() : 0,
					   c => JsonConvert.DeserializeObject<Dictionary<DegreeType, TimeSpan>>(JsonConvert.SerializeObject(c)) 
							?? new Dictionary<DegreeType, TimeSpan>()) 
				   )
				   .IsRequired();
			builder.Property(p => p.FoundationDate).IsRequired();

			builder.HasMany(asc => asc.TaughtDomains)
				   .WithOne(tsd => tsd.ArcaneSchool)
				   .HasForeignKey(tsd => tsd.IdArcaneSchool)
				   .IsRequired();

			builder.HasMany(asc => asc.ForbiddenDomains)
				   .WithOne(fsd => fsd.ArcaneSchool)
				   .HasForeignKey(fsd => fsd.IdArcaneSchool)
				   .IsRequired(false);

			builder.HasMany(asc => asc.Enrollments)
				   .WithOne(e => e.ArcaneSchool)
				   .HasForeignKey(e => e.IdArcaneSchool)
				   .IsRequired();
		}
	}
}
