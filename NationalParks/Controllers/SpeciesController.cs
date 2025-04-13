using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpeciesController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public SpeciesController( AppDBContext appDBContext  ) { 
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var Speciess = await _AppDBContext.Species.ToListAsync();
            return View(Speciess);
        }


        public async Task<IActionResult> CreateSpecies()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecies(Species Species)
        {
            await _AppDBContext.Species.AddAsync(Species);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditSpecies(int id)
        {
            Species Species =  await _AppDBContext.Species.FirstAsync(c => c.Id == id);
            return View(Species);
        }

        [HttpPost]
        public async Task<IActionResult> EditSpecies(Species Species)
        {
            _AppDBContext.Species.Update(Species);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            Species Species = await _AppDBContext.Species.FirstAsync(c => c.Id == id);
            _AppDBContext.Species.Remove(Species);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
