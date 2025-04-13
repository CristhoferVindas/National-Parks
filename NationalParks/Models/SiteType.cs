using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class SiteType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
         
    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
