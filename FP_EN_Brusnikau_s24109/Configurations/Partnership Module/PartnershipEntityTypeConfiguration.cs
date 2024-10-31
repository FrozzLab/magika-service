using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FP_EN_Brusnikau_s24109.Configurations.Partnership_Module
{
	public class PartnershipEntityTypeConfiguration : IEntityTypeConfiguration<Partnership>
	{
		public void Configure(EntityTypeBuilder<Partnership> builder)
		{
			builder.HasKey(k => k.IdPartnership).HasName("PK_Partnerships");

			builder.ToTable("Partnerships");

			builder.Property(p => p.Title).HasMaxLength(Application.MaxTitleLength).IsRequired();
			builder.Property(p => p.Goal).IsRequired();
			builder.Property(p => p.PartnershipStart).IsRequired();
			builder.Property(p => p.PartnershipEnd);
			builder.Property(p => p.MonthlyContribution).IsRequired();
			builder.Property(p => p.Status).IsRequired();

			builder.HasOne(p => p.Mage)
				   .WithMany(m => m.Partnerships)
				   .HasForeignKey(p => p.IdMage)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(p => p.Benefactor)
				   .WithMany(b => b.Partnerships)
				   .HasForeignKey(p => p.IdBenefactor)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
