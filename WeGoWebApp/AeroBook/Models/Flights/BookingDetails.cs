using System.ComponentModel.DataAnnotations;

namespace AeroBook.Models.Flights
{
    public class BookingDetails
    {
        //should map with the flightid and passenger details check in time and check out
        [Key]
        public int BookingId { get; set; }

        public int FlightId { get; set; }
        public string PaasengerName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string AadharId { get; set; }
        public virtual Flightdetails Flightdetails { get; set; }
    }
}
