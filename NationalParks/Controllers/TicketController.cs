using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;

namespace NationalParks.Controllers
{
    public class TicketController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        public TicketController( AppDBContext appDBContext  ) { 
            _AppDBContext = appDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var Tickets = await _AppDBContext.Tickets.ToListAsync();
            return View(Tickets);
        }


        public async Task<IActionResult> CreateTicket()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket Ticket)
        {
            await _AppDBContext.Tickets.AddAsync(Ticket);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditTicket(int id)
        {
            Ticket Ticket =  await _AppDBContext.Tickets.FirstAsync(c => c.Id == id);
            return View(Ticket);
        }

        [HttpPost]
        public async Task<IActionResult> EditTicket(Ticket Ticket)
        {
            _AppDBContext.Tickets.Update(Ticket);
            await _AppDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            Ticket Ticket = await _AppDBContext.Tickets.FirstAsync(c => c.Id == id);
            _AppDBContext.Tickets.Remove(Ticket);
            _AppDBContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

    }
}
