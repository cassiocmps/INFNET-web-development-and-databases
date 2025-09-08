using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CityBreaks.Web.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;
        public CityService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties)
                .ToListAsync();
        }

        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties)
                .FirstOrDefaultAsync(c => EF.Functions.Collate(c.Name, "NOCASE") == name);
        }

        public async Task<List<SelectListItem>> GetCitySelectListAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        public async Task<Property?> GetPropertyByIdAsync(int id)
        {
            return await _context.Properties.FindAsync(id);
        }

        public async Task<bool> CreatePropertyAsync(CreatePropertyViewModel model)
        {
            var property = new Property
            {
                Name = model.Name,
                PricePerNight = model.PricePerNight,
                CityId = model.CityId
            };
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePropertyAsync(int id, EditPropertyViewModel model)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null) return false;
            property.Name = model.Name;
            property.PricePerNight = model.PricePerNight;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
