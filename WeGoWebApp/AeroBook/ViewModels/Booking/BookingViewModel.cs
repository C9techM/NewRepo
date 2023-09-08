namespace AeroBook.ViewModels.Booking
{
    public class BookingViewModel
    {
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV { get; set; }
        public string CardholderName { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public bool AcceptTerms { get; set; }

    }
}
