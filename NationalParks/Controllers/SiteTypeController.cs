using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SiteTypeController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public SiteTypeController( AppDBContext appDBContext  ) { 
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var SiteTypes = await _AppDBContext.SiteTypes.ToListAsync();
            return View(SiteTypes);
        }


        public async Task<IActionResult> CreateSiteType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSiteType(SiteType SiteType)
        {
            await _AppDBContext.SiteTypes.AddAsync(SiteType);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditSiteType(int id)
        {
            SiteType SiteType =  await _AppDBContext.SiteTypes.FirstAsync(c => c.Id == id);
            return View(SiteType);
        }

        [HttpPost]
        public async Task<IActionResult> EditSiteType(SiteType SiteType)
        {
            _AppDBContext.SiteTypes.Update(SiteType);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSiteType(int id)
        {
            SiteType SiteType = await _AppDBContext.SiteTypes.FirstAsync(c => c.Id == id);
            _AppDBContext.SiteTypes.Remove(SiteType);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
