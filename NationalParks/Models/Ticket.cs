using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public DateOnly SaleDate { get; set; }

    public int Commission { get; set; }

    public int? cardId { get; set; }

    public int? PlaceId { get; set; }

    public int? TicketSaleId { get; set; }
    public virtual Card? CardNavigation { get; set; }

    public virtual Place? PlaceNavigation { get; set; }

    public virtual TicketSale? TicketSale { get; set; }
}
