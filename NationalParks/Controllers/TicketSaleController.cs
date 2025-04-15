using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParks.Data;
using NationalParks.Models;
using NationalParks.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParks.Controllers
{
    public class TicketSaleController : Controller
    {
        private readonly AppDBContext _AppDBContext;
        private static List<Ticket> _ticketCart = new List<Ticket>();
        private static int count = 0;
        public TicketSaleController(AppDBContext appDBContext)
        {
            _AppDBContext = appDBContext;
        }

        public async Task<IActionResult> List()
        {
            var ticketSales = await _AppDBContext.TicketSales.Include(t => t.Tickets).Include("Visitor").Include("Card").ToListAsync();
            return View(ticketSales);
        }

        public async Task<IActionResult> CreateTicketSale()
        {
            var visitors = await _AppDBContext.Visitors.ToListAsync();
            var cards = await _AppDBContext.Cards.ToListAsync();
            var places = await _AppDBContext.Places.ToListAsync();
            _ticketCart.Clear();

            var ticketSaleViewModel = new TicketSaleViewModel
            {
                Cards = cards,
                Visitors = visitors,
                TicketSale = new TicketSale(),
                Places = places,
                Tickets = _ticketCart,
                Ticket = new Ticket()
            };
            return View(ticketSaleViewModel);
        }

        // Acción para agregar un ticket
        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody]TicketSaleViewModel ticketSaleViewModel)
        {
            count++;
            // Buscar el lugar y la tarjeta por sus ID
            var place = await _AppDBContext.Places.FindAsync(ticketSaleViewModel.PlaceId);
            var card = await _AppDBContext.Cards.FindAsync(ticketSaleViewModel.CardId);

            // Verificar si el lugar o la tarjeta no existen
            if (place == null || card == null)
            {
                return BadRequest("Lugar o tarjeta no válidos.");
            }

            // Crear un nuevo ticket
            var ticket = new Ticket
            {
                PlaceNavigation = place,
                
                Price = ticketSaleViewModel.Ticket.SaleDate.DayOfWeek == DayOfWeek.Sunday ?  place.SundayPrice : place.Price,
                Commission = card.Commission,
                SaleDate = ticketSaleViewModel.Ticket.SaleDate,
                PlaceId = place.Id,
                cardId = card.Id,
            };

            // Agregar el ticket al carrito de ventas
            _ticketCart.Add(ticket);

            // Devolver una vista parcial con la lista de tickets actualizada
            return PartialView("_TicketListPartial", _ticketCart);
        }



        [HttpPost]
        public async Task<IActionResult> RemoveTicket(int id)
        {
            var ticket = await _AppDBContext.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return BadRequest("El ticket no existe.");
            }

            _AppDBContext.Tickets.Remove(ticket);
            await _AppDBContext.SaveChangesAsync();

            // Opcional: Si tenés un carrito o una lista en memoria (como _ticketCart), actualizalo aquí.
            // Por ejemplo, si también estás usando _ticketCart:
            _ticketCart.RemoveAll(t => t.Id == id); // Asegurate de que Ticket tenga un Id cargado

            // Luego retornás la vista parcial actualizada:
            return PartialView("_TicketListPartial", _ticketCart);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmSale(int customerId, int cardId)
        {
            var customer = await _AppDBContext.Visitors.FindAsync(customerId);
            var card = await _AppDBContext.Cards.FindAsync(cardId);

            if (customer == null || card == null)
            {
                return BadRequest("Cliente o tarjeta no válidos.");
            }

            foreach (var ticket in _ticketCart)
            {
                _AppDBContext.Tickets.Add(ticket);
            }

            await _AppDBContext.SaveChangesAsync();
            _ticketCart.Clear();

            return RedirectToAction("List");
        }
      
        [HttpPost]
        public async Task<IActionResult> CreateTicketSale(TicketSaleViewModel ticketSaleViewModel)
        {
            if (_ticketCart.Count == 0)
            {
                return RedirectToAction("CreateTicketSale");
            }
            DateTime localDate = DateTime.Now;
            var visitor = await _AppDBContext.Visitors.FindAsync(ticketSaleViewModel.TicketSale.VisitorId);
            ticketSaleViewModel.TicketSale.TotalPrice = _ticketCart.Sum(t => t.Price);

            ticketSaleViewModel.TicketSale.Tickets = new List<Ticket>(_ticketCart);
            ticketSaleViewModel.TicketSale.TotalPrice = _ticketCart.Sum(t => t.Price);
            ticketSaleViewModel.TicketSale.Customer = visitor.FirstName + " " + visitor.LastName ;
            ticketSaleViewModel.TicketSale.SaleDate = localDate;


            foreach (var ticket in ticketSaleViewModel.TicketSale.Tickets)
            {
                ticket.PlaceNavigation = null;
            }
            await _AppDBContext.TicketSales.AddAsync(ticketSaleViewModel.TicketSale);
            await _AppDBContext.SaveChangesAsync();

            _ticketCart.Clear();

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> EditTicketSale(int id)
        {
            var ticketSale = await _AppDBContext.TicketSales
        .Include(t => t.Tickets)
        .ThenInclude(t => t.PlaceNavigation) // Para obtener los lugares asociados a los tickets
        .FirstOrDefaultAsync(t => t.Id == id);
            _ticketCart = ticketSale.Tickets.ToList();
            if (ticketSale == null)
            {
                return NotFound();
            }

            // Crear un ViewModel con los datos necesarios para la vista
            var viewModel = new TicketSaleViewModel
            {
                TicketSale = ticketSale,
                Visitors = await _AppDBContext.Visitors.ToListAsync(),
                Cards = await _AppDBContext.Cards.ToListAsync(),
                Places = await _AppDBContext.Places.ToListAsync(),
                Tickets = _ticketCart
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditTicketSale(TicketSaleViewModel ticketSaleViewModel)
        {
            if (_ticketCart.Count == 0)
            {
                return RedirectToAction("CreateTicketSale");
            }

            int saleId = ticketSaleViewModel.TicketSale.Id;
            var existingSale = await _AppDBContext.TicketSales
                .Include(ts => ts.Tickets)
                .FirstOrDefaultAsync(ts => ts.Id == saleId);

            if (existingSale == null)
            {
                return NotFound();
            }

            var visitor = await _AppDBContext.Visitors.FindAsync(ticketSaleViewModel.TicketSale.VisitorId);
            var card = await _AppDBContext.Cards.FindAsync(ticketSaleViewModel.TicketSale.CardId);


            var existingTicketIds = existingSale.Tickets.Select(t => t.Id).ToList();
            var newTicketIds = _ticketCart.Select(t => t.Id).ToList();

            // Eliminar los tickets que ya no están
            var ticketsToRemove = existingSale.Tickets
                .Where(t => !newTicketIds.Contains(t.Id))
                .ToList();

            _AppDBContext.Tickets.RemoveRange(ticketsToRemove);

            // Agregar los tickets nuevos
            var ticketsToAdd = _ticketCart
                .Where(t => !existingTicketIds.Contains(t.Id))
                .ToList();

            foreach (var ticket in ticketsToAdd)
            {
                ticket.PlaceNavigation = null;
                existingSale.Tickets.Add(ticket);
            }

            existingSale.TotalPrice = existingSale.Tickets.Sum(t => t.Price);
            existingSale.Customer = visitor.FirstName + " " + visitor.LastName;
            existingSale.VisitorId = visitor.Id;
            existingSale.CardId = card.Id;

            existingSale.SaleDate = DateTime.Now;

            _AppDBContext.TicketSales.Update(existingSale);
            await _AppDBContext.SaveChangesAsync();

            _ticketCart.Clear();

            return RedirectToAction(nameof(List));
        }


        [HttpGet]
        public async Task<IActionResult> DeleteTicketSale(int id)
        {
            var ticketSale = await _AppDBContext.TicketSales.FindAsync(id);
            if (ticketSale == null)
            {
                return NotFound();
            }

            _AppDBContext.TicketSales.Remove(ticketSale);
            await _AppDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }
    }
}
