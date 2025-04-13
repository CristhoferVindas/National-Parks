using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {

        private readonly AppDBContext _AppDBContext;
        public CountryController(AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var Countrys = await _AppDBContext.Countries.ToListAsync();
            return View(Countrys);
        }


        public async Task<IActionResult> CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(Country Country)
        {
            await _AppDBContext.Countries.AddAsync(Country);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditCountry(int id)
        {
            Country Country = await _AppDBContext.Countries.FirstAsync(c => c.Id == id);
            return View(Country);
        }

        [HttpPost]
        public async Task<IActionResult> EditCountry(Country Country)
        {
            _AppDBContext.Countries.Update(Country);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            Country Country = await _AppDBContext.Countries.FirstAsync(c => c.Id == id);
            _AppDBContext.Countries.Remove(Country);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
