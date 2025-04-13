using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;
using NationalParks.Models.ViewModels;
using NationalParks.Data;
namespace NationalParks.Controllers
{
    public class PlaceRatingController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public PlaceRatingController(AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var PlaceRatings = await _AppDBContext.PlaceRatings.Include("Place").ToListAsync();

            return View(PlaceRatings);
        }


        public async Task<IActionResult> CreatePlaceRating()
        {
            var places = await _AppDBContext.Places.ToListAsync();
            var PlaceRatingViewModel = new PlaceRatingViewModel
            {
                Places = places,
                PlaceRating = new PlaceRating()
            };
            return View(PlaceRatingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaceRating(PlaceRatingViewModel PlaceRatingViewModel)
        {
            await _AppDBContext.PlaceRatings.AddAsync(PlaceRatingViewModel.PlaceRating);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditPlaceRating(int id)
        {
            PlaceRating PlaceRating = await _AppDBContext.PlaceRatings.FirstAsync(c => c.Id == id);
            var places = await _AppDBContext.Places.ToListAsync();
            var PlaceRatingViewModel = new PlaceRatingViewModel
            {
                Places = places,
                PlaceRating = PlaceRating
            };

            return View(PlaceRatingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlaceRating(PlaceRatingViewModel PlaceRatingViewModel)
        {
            _AppDBContext.PlaceRatings.Update(PlaceRatingViewModel.PlaceRating);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeletePlaceRating(int id)
        {
            PlaceRating PlaceRating = await _AppDBContext.PlaceRatings.FirstAsync(c => c.Id == id);
            _AppDBContext.PlaceRatings.Remove(PlaceRating);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
