using System.Diagnostics;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using CityBreaks.Web.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CityBreaks.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
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
            var viewModel = new CreatePropertyViewModel
            {
                Cities = await _cityService.GetCitySelectListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(CreatePropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cities = await _cityService.GetCitySelectListAsync();
                return View(model);
            }
            await _cityService.CreatePropertyAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProperty(int id)
        {
            var property = await _cityService.GetPropertyByIdAsync(id);
            if (property == null)
                return NotFound();
            var viewModel = new EditPropertyViewModel
            {
                Id = property.Id,
                Name = property.Name,
                PricePerNight = property.PricePerNight
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProperty(int id, EditPropertyViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var success = await _cityService.UpdatePropertyAsync(id, model);
            if (!success)
                return NotFound();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProperty()
        {
            var cities = await _cityService.GetAllAsync();
            ViewBag.Cities = cities;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _cityService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
