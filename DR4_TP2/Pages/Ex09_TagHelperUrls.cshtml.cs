using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages
{
    public class Ex09_TagHelperUrlsModel : PageModel
    {
        public List<string> Cities { get; set; } = new();

        public void OnGet()
        {
            Cities = new List<string>
            {
                "Rio de Janeiro",
                "São Paulo", 
                "Brasília"
            };
        }
    }
}