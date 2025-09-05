using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages
{
    public class Ex05_ComplexObjectModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public Country? CreatedCountry { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Country name is required.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Country code is required.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;

            public Country(string countryName, string countryCode)
            {
                CountryName = countryName;
                CountryCode = countryCode;
            }
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                CreatedCountry = new Country(Input.CountryName, Input.CountryCode);
            }

            return Page();
        }
    }
}