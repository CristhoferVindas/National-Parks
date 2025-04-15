using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Continent { get; set; } = null!;

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
