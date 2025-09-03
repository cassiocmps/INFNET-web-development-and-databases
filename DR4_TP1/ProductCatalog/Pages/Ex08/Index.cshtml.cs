using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ProductCatalog.Pages.Ex08
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 1200.00m },
                new Product { Name = "Smartphone", Price = 800.00m },
                new Product { Name = "Headphones", Price = 150.00m }
            };
        }
    }
}
