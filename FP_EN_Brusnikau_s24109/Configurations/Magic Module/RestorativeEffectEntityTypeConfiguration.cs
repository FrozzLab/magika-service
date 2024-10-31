using FP_EN_Brusnikau_s24109.Classes;
using FP_EN_Brusnikau_s24109.Classes.Models.Magic_Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FP_EN_Brusnikau_s24109.Configurations.Magic_Module
{
	public class RestorativeEffectEntityTypeConfiguration : IEntityTypeConfiguration<RestorativeEffect>
	{
		public void Configure(EntityTypeBuilder<RestorativeEffect> builder)
		{
			builder.ToTable("Restorative_Effects");

			builder.Property(p => p.CuredAilments)
				.HasConversion
				   (
					   ca => JsonConvert.SerializeObject(ca),
					   ca => JsonConvert.DeserializeObject<List<AilmentType>>(ca) ?? new List<AilmentType>(),
					   new ValueComparer<List<AilmentType>>(
					   (c1, c2) => JsonConvert.SerializeObject(c1) == JsonConvert.SerializeObject(c2),
					   c => c != null ? JsonConvert.SerializeObject(c).GetHashCode() : 0,
					   c => JsonConvert.DeserializeObject<List<AilmentType>>(JsonConvert.SerializeObject(c))
							?? new List<AilmentType>())
				   )
				.IsRequired();
		}
	}
}
