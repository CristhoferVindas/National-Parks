using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public LocationController(AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var Locations = await _AppDBContext.Locations.ToListAsync();
            return View(Locations);
        }


        public async Task<IActionResult> CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(Location Location)
        {
            await _AppDBContext.Locations.AddAsync(Location);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditLocation(int id)
        {
            Location Location = await _AppDBContext.Locations.FirstAsync(c => c.Id == id);
            return View(Location);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(Location Location)
        {
            _AppDBContext.Locations.Update(Location);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            Location Location = await _AppDBContext.Locations.FirstAsync(c => c.Id == id);
            _AppDBContext.Locations.Remove(Location);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
