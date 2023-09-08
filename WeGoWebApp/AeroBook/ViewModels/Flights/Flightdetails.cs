
namespace AeroBook.ViewModels.Flights
{
    public class Flightdetails
    {
        public int FlightId { get; set; }
        public string FightName { get; set; }
        public string Availability { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int PricePerPerson { get; set; }
    }
}
