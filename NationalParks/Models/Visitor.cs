using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public int IdnumberOrPassport { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string VisitReason { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<TicketSale> TicketSales { get; set; } = new List<TicketSale>();
}
