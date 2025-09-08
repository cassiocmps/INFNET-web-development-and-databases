using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");
            builder.Property(p => p.PricePerNight)
                .HasColumnName("PricePerNight");
            builder.Property(p => p.CityId)
                .HasColumnName("CityId");
        }
    }
}
