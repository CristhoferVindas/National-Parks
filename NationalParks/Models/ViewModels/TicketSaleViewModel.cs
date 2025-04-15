namespace NationalParks.Models.ViewModels
{
    public class TicketSaleViewModel
    {
        public TicketSale TicketSale { get; set; }
        public List<Card> Cards { get; set; }
        public int CardId { get; set; }
        public int PlaceId { get; set; }
        public List<Visitor> Visitors { get; set; }
        public List<Place> Places { get; set; }
        public Ticket Ticket { get; set; }
        public List<Ticket> Tickets { get; set; }





    }
}
