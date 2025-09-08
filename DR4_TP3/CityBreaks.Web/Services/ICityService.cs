using CityBreaks.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CityBreaks.Web.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByNameAsync(string name);
        Task<List<SelectListItem>> GetCitySelectListAsync();
        Task<Property?> GetPropertyByIdAsync(int id);
        Task<bool> CreatePropertyAsync(CreatePropertyViewModel model);
        Task<bool> UpdatePropertyAsync(int id, EditPropertyViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string cityName, string propertyName);
    }
}
