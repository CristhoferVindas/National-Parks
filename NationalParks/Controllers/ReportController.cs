using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NationalParks.Data;
using NationalParks.Models.ViewModels;

namespace NationalParks.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public ReportController(AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Pays()
        {
            return View();
        }

        public IActionResult Rating()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult GenerateRatingReport()
        {
            return View();
        }
    }
}
