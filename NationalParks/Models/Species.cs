using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class Species
{
    public int Id { get; set; }

    public string SpeciesType { get; set; } = null!;

    public string ScientificName { get; set; } = null!;

    public string CommonName { get; set; } = null!;

    public int? Weight { get; set; }

    public int? Height { get; set; }

    public string SpecialCharacteristics { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
