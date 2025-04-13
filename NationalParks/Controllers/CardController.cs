using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CardController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public CardController( AppDBContext appDBContext  ) { 
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var cards = await _AppDBContext.Cards.ToListAsync();
            return View(cards);
        }


        public async Task<IActionResult> CreateCard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(Card card)
        {
            await _AppDBContext.Cards.AddAsync(card);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditCard(int id)
        {
            Card card =  await _AppDBContext.Cards.FirstAsync(c => c.Id == id);
            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> EditCard(Card card)
        {
            _AppDBContext.Cards.Update(card);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteCard(int id)
        {
            Card card = await _AppDBContext.Cards.FirstAsync(c => c.Id == id);
            _AppDBContext.Cards.Remove(card);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
