using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Card
{
    public int Id { get; set; }

    public string CardType { get; set; } = null!;

    public int Commission { get; set; }

    public virtual ICollection<TicketSale> TicketSales { get; set; } = new List<TicketSale>();
}
