using System.ComponentModel.DataAnnotations;

namespace AeroBook.ViewModels.Flights
{
    public class BookingDetails
    {
        //should map with the flightid and passenger details check in time and check out
        public int BookingId { get; set; }

        public int FlightId { get; set; }
        public int PaymentMode { get; set; }
        public int noOfPersons { get; set; }
        public int TotalPay { get; set; }
        public int paymentStatus { get; set; }
    }
}
