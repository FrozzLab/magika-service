using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Partnership_Module
{
	public class BenefactorEntityTypeConfiguration : IEntityTypeConfiguration<Benefactor>
	{
		public void Configure(EntityTypeBuilder<Benefactor> builder)
		{
			builder.HasKey(k => k.IdBenefactor).HasName("PK_Benefactors");

			builder.UseTptMappingStrategy().ToTable("Benefactors");

			builder.Property(p => p.Name).HasMaxLength(ArcaneSchool.MaxNameLength).IsRequired();
			builder.Property(p => p.EstablishmentDate).IsRequired();

			builder.HasMany(b => b.Partnerships)
				   .WithOne(p => p.Benefactor)
				   .HasForeignKey(p => p.IdBenefactor)
				   .IsRequired();

			builder.HasMany(b => b.Applications)
				   .WithOne(a => a.Benefactor)
				   .HasForeignKey(a => a.IdBenefactor)
				   .IsRequired();
		}
	}
}
