using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityBreaks.Web.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PricePerNight { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public DateTime? DeletedAt { get; set; }
    }
}
