using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Configurations.Partnership_Module
{
	public class KingdomEntityTypeConfiguration : IEntityTypeConfiguration<Kingdom>
	{
		public void Configure(EntityTypeBuilder<Kingdom> builder)
		{
			builder.ToTable("Kingdoms");

			builder.Property(p => p.SuccessionOrder)
				   .HasConversion
				   (
					   so => JsonConvert.SerializeObject(so),
					   so => JsonConvert.DeserializeObject<List<string>>(so) ?? new List<string>(),
					   new ValueComparer<List<string>>(
					   (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
					   c => c != null ? JsonConvert.SerializeObject(c).GetHashCode() : 0,
					   c => JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(c))
							?? new List<string>())
				   )
				   .IsRequired();

			builder.HasMany(k => k.NobleHouses)
				   .WithOne(nh => nh.Kingdom)
				   .HasForeignKey(nh => nh.IdKingdom)
				   .IsRequired();
		}
	}
}
