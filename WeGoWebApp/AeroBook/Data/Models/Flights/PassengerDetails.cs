namespace AeroBook.Models.Flights
{
    public class PassengerDetails
    {
        public string PaasengerName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string AadharId { get; set; }
        public int BookingId { get; set; }
        public virtual BookingDetails BookingDetails { get; set; }
    }
}
