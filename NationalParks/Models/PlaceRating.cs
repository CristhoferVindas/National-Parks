using System;
using System.Collections.Generic;

namespace NationalParks.Models;

public partial class PlaceRating
{
    public int Id { get; set; }

    public int Stars { get; set; }

    public string Observation { get; set; } = null!;

    public int? PlaceId { get; set; }

    public virtual Place? Place { get; set; }
}
