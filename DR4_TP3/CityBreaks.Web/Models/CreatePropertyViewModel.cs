using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CityBreaks.Web.Models
{
    public class CreatePropertyViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal PricePerNight { get; set; }

        [Required]
        public int CityId { get; set; }

        public List<SelectListItem> Cities { get; set; } = new();
    }
}
