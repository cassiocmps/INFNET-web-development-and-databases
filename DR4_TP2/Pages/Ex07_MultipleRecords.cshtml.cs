using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages
{
    public class Ex07_MultipleRecordsModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Countries { get; set; } = new();

        public List<Country> SubmittedCountries { get; set; } = new();
        public bool IsSubmitted { get; set; } = false;

        public class InputModel
        {
            [Required(ErrorMessage = "Country name is required.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Country code is required.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "Country code must be exactly 2 characters.")]
            [RegularExpression(@"^[A-Za-z]{2}$", ErrorMessage = "Country code must contain only letters.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;

            public Country(string countryName, string countryCode)
            {
                CountryName = countryName;
                CountryCode = countryCode.ToUpper();
            }
        }

        public void OnGet()
        {
            Countries = new List<InputModel>();
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        public IActionResult OnPost()
        {
            IsSubmitted = true;

            var validEntries = Countries.Where(c => 
                !string.IsNullOrWhiteSpace(c.CountryName) && 
                !string.IsNullOrWhiteSpace(c.CountryCode)).ToList();

            SubmittedCountries = new List<Country>();
            foreach (var entry in validEntries)
            {
                if (!string.IsNullOrWhiteSpace(entry.CountryName) && 
                    !string.IsNullOrWhiteSpace(entry.CountryCode) &&
                    entry.CountryCode.Length == 2)
                {
                    SubmittedCountries.Add(new Country(entry.CountryName, entry.CountryCode));
                }
            }

            while (Countries.Count < 5)
            {
                Countries.Add(new InputModel());
            }

            return Page();
        }
    }
}