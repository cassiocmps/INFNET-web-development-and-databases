using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");
            builder.Property(c => c.CountryId)
                .HasColumnName("CountryId");

            builder.HasData(
                new City { Id = 1, Name = "Paris", CountryId = 1 },
                new City { Id = 2, Name = "Rome", CountryId = 2 }
            );
        }
    }
}
