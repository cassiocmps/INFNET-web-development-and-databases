using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages
{
    public class Ex08_RouteParametersModel : PageModel
    {
        public string CityName { get; set; } = string.Empty;

        public void OnGet(string cityName)
        {
            CityName = cityName ?? string.Empty;
        }
    }
}