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
            builder.Property(p => p.DeletedAt)
                .HasColumnName("DeletedAt");

            builder.HasData(
                new Property { Id = 1, Name = "Eiffel Tower View Apartment", PricePerNight = 150, CityId = 1 },
                new Property { Id = 2, Name = "Colosseum Studio", PricePerNight = 120, CityId = 2 }
            );
        }
    }
}
