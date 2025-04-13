namespace NationalParks.Models.ViewModels
{
    public class PlaceViewModel
    {
        public Place Place { get; set; }
        public List<SiteType> SiteTypes { get; set; }
        public List<Location> Locations { get; set; }
    }
}
