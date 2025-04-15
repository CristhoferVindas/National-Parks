using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Location
{
    public int Id { get; set; }

    public string Province { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public string District { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
