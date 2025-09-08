using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CityBreaks.Web.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string CountryName { get; set; } = string.Empty;

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string CountryCode { get; set; } = string.Empty;

        public List<City> Cities { get; set; } = new();
    }
}
