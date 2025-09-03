using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Pages.Ex10
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public string ProductName { get; set; }
        [BindProperty]
        public decimal ProductPrice { get; set; }
        public bool ShowResult { get; set; }

        public void OnGet()
        {
            ShowResult = false;
        }

        public void OnPost()
        {
            ShowResult = true;
        }
    }
}
