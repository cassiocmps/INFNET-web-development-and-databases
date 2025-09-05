using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages
{
    public class Ex02_HandlerParametersModel : PageModel
    {
        public string SubmittedCityName { get; set; } = string.Empty;

        public void OnGet() { }

        public IActionResult OnPost(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                SubmittedCityName = cityName;
            }

            return Page();
        }
    }
}