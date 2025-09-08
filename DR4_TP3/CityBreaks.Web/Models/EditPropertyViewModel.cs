using System.ComponentModel.DataAnnotations;

namespace CityBreaks.Web.Models
{
    public class EditPropertyViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PricePerNight { get; set; }
    }
}
