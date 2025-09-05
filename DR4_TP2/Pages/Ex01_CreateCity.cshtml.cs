using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages
{
    public class Ex01_CreateCityModel : PageModel
    {
        [BindProperty]
        public string CityName { get; set; } = string.Empty;

        public string SubmittedCityName { get; set; } = string.Empty;

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(CityName))
            {
                SubmittedCityName = CityName;
            }

            return Page();
        }
    }
}