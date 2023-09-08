using System.ComponentModel.DataAnnotations;

namespace AeroBook.Models.Flights
{
    public class BookingDetails
    {
        //should map with the flightid and passenger details check in time and check out
        [Key]
        public int BookingId { get; set; }

        public int FlightId { get; set; }
        public int PaymentMode { get; set; }
        public int noOfPersons { get; set; }
        public int TotalPay { get; set; }
        public int paymentStatus { get; set; }

        public virtual Flightdetails Flightdetails { get; set; }
    }
}
