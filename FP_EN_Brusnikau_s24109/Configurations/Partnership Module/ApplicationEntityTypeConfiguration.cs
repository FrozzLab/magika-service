using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Configurations.Partnership_Module
{
	public class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Application>
	{
		public void Configure(EntityTypeBuilder<Application> builder)
		{
			builder.HasKey(k => k.IdApplication).HasName("PK_Applications");

			builder.ToTable("Applications");

			builder.Property(p => p.Title).HasMaxLength(Application.MaxTitleLength).IsRequired();
			builder.Property(p => p.Goal).IsRequired();
			builder.Property(p => p.OfferHistory)
				   .HasConversion
				   (
					   oh => JsonConvert.SerializeObject(oh),
					   oh => JsonConvert.DeserializeObject<List<Offer>>(oh) ?? new List<Offer>(),
					   new ValueComparer<List<Offer>>(
					   (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
					   c => c != null ? JsonConvert.SerializeObject(c).GetHashCode() : 0,
					   c => JsonConvert.DeserializeObject<List<Offer>>(JsonConvert.SerializeObject(c))
							?? new List<Offer>())
				   )
				   .IsRequired();
			builder.Property(p => p.NextToRespond).IsRequired();
			builder.Property(p => p.Status).IsRequired();

			builder.HasOne(a => a.Mage)
				   .WithMany(m => m.Applications)
				   .HasForeignKey(a => a.IdMage)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();

			builder.HasOne(a => a.Benefactor)
				   .WithMany(b => b.Applications)
				   .HasForeignKey(a => a.IdBenefactor)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
