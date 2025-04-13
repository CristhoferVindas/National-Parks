using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class TicketSale
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime SaleDate { get; set; }

    public string Customer { get; set; } = null!;

    public int? CardId { get; set; }

    public int? VisitorId { get; set; }

    public virtual Card? Card { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Visitor? Visitor { get; set; }
}
