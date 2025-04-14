using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;
using NationalParks.Models.ViewModels;

namespace NationalParks.Controllers
{

    public class VisitorController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public VisitorController( AppDBContext appDBContext  ) { 
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var Visitors = await _AppDBContext.Visitors.Include("Country").ToListAsync();
            return View(Visitors);
        }


        public async Task<IActionResult> CreateVisitor()
        {
            var contries = await _AppDBContext.Countries.ToListAsync();
            var visitorViewModel = new VisitorViewModel
            {
                Countries = contries,
                Visitor = new Visitor()
            };

            return View(visitorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitor(VisitorViewModel visitorViewModel)
        {
            await _AppDBContext.Visitors.AddAsync(visitorViewModel.Visitor);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditVisitor(int id)
        {
            Visitor Visitor =  await _AppDBContext.Visitors.FirstAsync(c => c.Id == id);
            var contries = await _AppDBContext.Countries.ToListAsync();
            var visitorViewModel = new VisitorViewModel
            {
                Countries = contries,
                Visitor = Visitor
            };

            return View(visitorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditVisitor(VisitorViewModel visitorViewModel)
        {
            _AppDBContext.Visitors.Update(visitorViewModel.Visitor);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            Visitor Visitor = await _AppDBContext.Visitors.FirstAsync(c => c.Id == id);
            _AppDBContext.Visitors.Remove(Visitor);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
