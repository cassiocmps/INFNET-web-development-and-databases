using System.Diagnostics;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using CityBreaks.Web.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICityService _cityService;
        private readonly CityBreaksContext _context;

        public HomeController(ILogger<HomeController> logger, ICityService cityService, CityBreaksContext context)
        {
            _logger = logger;
            _cityService = cityService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityService.GetAllAsync();
            return View(cities);
        }

        public async Task<IActionResult> CityDetails(string name)
        {
            var city = await _cityService.GetByNameAsync(name);
            if (city == null)
                return NotFound();
            return View(city);
        }

        public async Task<IActionResult> CreateProperty()
        {
            var cities = await _cityService.GetAllAsync();
            var viewModel = new CreatePropertyViewModel
            {
                Cities = cities.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var cities = await _cityService.GetAllAsync();
                model.Cities = cities.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                return View(model);
            }

            var property = new Property
            {
                Name = model.Name,
                PricePerNight = model.PricePerNight,
                CityId = model.CityId
            };

            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
