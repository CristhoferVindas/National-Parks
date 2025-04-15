using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Place
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Recognitions { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ReservedArea { get; set; } = null!;

    public int Coordinates { get; set; }
    public decimal Price { get; set; }
    public decimal SundayPrice { get; set; }
    public int? SiteTypeId { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ICollection<PlaceRating> PlaceRatings { get; set; } = new List<PlaceRating>();

    public virtual SiteType? SiteTypeNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Species> Species { get; set; } = new List<Species>();
}
