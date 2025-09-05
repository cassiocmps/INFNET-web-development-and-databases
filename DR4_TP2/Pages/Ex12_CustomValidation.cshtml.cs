using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages
{
    public class Ex12_CustomValidationModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public Country? CreatedCountry { get; set; }
        public bool IsSubmitted { get; set; } = false;

        public class InputModel
        {
            [Required(ErrorMessage = "Country name is required.")]
            [MinLength(2, ErrorMessage = "Country name must be at least 2 characters long.")]
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

        public void OnGet() { }

        public IActionResult OnPost()
        {
            IsSubmitted = true;

            // First check built-in validations
            if (ModelState.IsValid)
            {
                // Custom validation: First letter of country name must match first letter of country code
                var countryNameFirstLetter = Input.CountryName.Trim().ToUpper().FirstOrDefault();
                var countryCodeFirstLetter = Input.CountryCode.Trim().ToUpper().FirstOrDefault();

                if (countryNameFirstLetter != countryCodeFirstLetter)
                {
                    ModelState.AddModelError("CustomValidation", 
                        $"The first letter of the country name ('{countryNameFirstLetter}') must match the first letter of the country code ('{countryCodeFirstLetter}').");
                }
            }

            // If all validations pass (including custom ones)
            if (ModelState.IsValid)
            {
                // Create Country object from InputModel
                CreatedCountry = new Country(Input.CountryName, Input.CountryCode);
                
                // Clear the input for next use
                Input = new InputModel();
                IsSubmitted = false; // Reset for next submission
            }

            return Page();
        }
    }
}