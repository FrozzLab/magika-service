using FP_EN_Brusnikau_s24109.Classes.Models.Partnership_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Configurations.Partnership_Module
{
	public class NobleHouseEntityTypeConfiguration : IEntityTypeConfiguration<NobleHouse>
	{
		public void Configure(EntityTypeBuilder<NobleHouse> builder)
		{
			builder.ToTable("Noble_Houses");

			builder.Property(p => p.HouseType).IsRequired();
			builder.Property(p => p.BoardOfRulers)
				   .HasConversion
				   (
					   br => JsonConvert.SerializeObject(br),
					   br => JsonConvert.DeserializeObject<List<string>>(br) ?? new List<string>(),
					   new ValueComparer<List<string>>(
					   (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
					   c => c != null ? JsonConvert.SerializeObject(c).GetHashCode() : 0,
					   c => JsonConvert.DeserializeObject<List<string>>(JsonConvert.SerializeObject(c))
							?? new List<string>())
				   )
				   .IsRequired();

			builder.HasOne(nh => nh.Kingdom)
				   .WithMany(k => k.NobleHouses)
				   .HasForeignKey(nh => nh.IdKingdom)
				   .OnDelete(DeleteBehavior.Cascade)
				   .IsRequired();
		}
	}
}
