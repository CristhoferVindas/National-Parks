using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;
using NationalParks.Models.ViewModels;
using NationalParks.Data;
using Microsoft.AspNetCore.Authorization;

namespace NationalParks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlaceController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public PlaceController(AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var Places = await _AppDBContext.Places.Include("SiteTypeNavigation").Include("LocationNavigation").ToListAsync();

            return View(Places);
        }


        public async Task<IActionResult> CreatePlace()
        {
            var SiteTypes = await _AppDBContext.SiteTypes.ToListAsync();
            var locations = await _AppDBContext.Locations.ToListAsync();

            var placeViewModel = new PlaceViewModel
            {
                Locations = locations,
                SiteTypes = SiteTypes,
                Place = new Place()
            };
            return View(placeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlace(PlaceViewModel placeViewModel)
        {
            await _AppDBContext.Places.AddAsync(placeViewModel.Place);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditPlace(int id)
        {
            Place place = await _AppDBContext.Places.FirstAsync(c => c.Id == id);
            var SiteTypes = await _AppDBContext.SiteTypes.ToListAsync();
            var locations = await _AppDBContext.Locations.ToListAsync();

            var placeViewModel = new PlaceViewModel
            {
                Locations = locations,
                SiteTypes = SiteTypes,
                Place = place
            };
          
            return View(placeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlace(PlaceViewModel placeViewModel)
        {
            _AppDBContext.Places.Update(placeViewModel.Place);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeletePlace(int id)
        {
            Place Place = await _AppDBContext.Places.FirstAsync(c => c.Id == id);
            _AppDBContext.Places.Remove(Place);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
