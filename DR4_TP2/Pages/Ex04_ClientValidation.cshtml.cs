using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages
{
    public class Ex04_ClientValidationModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public bool IsSubmitted { get; set; } = false;

        public class InputModel
        {
            [Required(ErrorMessage = "City name is required.")]
            [MinLength(3, ErrorMessage = "City name must be at least 3 characters long.")]
            public string CityName { get; set; } = string.Empty;
        }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            IsSubmitted = true;

            if (ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}