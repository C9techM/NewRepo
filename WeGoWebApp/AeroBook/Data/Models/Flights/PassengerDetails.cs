using System.ComponentModel.DataAnnotations;
namespace AeroBook.Models.Flights

{
    public class PassengerDetails
    {
        [Key]
        public int PassengerId { get; set; }    
        public string PassengerName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string AadharId { get; set; }
        public int BookingId { get; set; }
        public virtual BookingDetails BookingDetails { get; set; }
    }
}
