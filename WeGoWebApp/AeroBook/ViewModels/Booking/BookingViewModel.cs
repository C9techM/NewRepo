using System.ComponentModel.DataAnnotations;

namespace AeroBook.ViewModels.Booking
{
    public class BookingViewModel
    {
        [Key]
        public int Id {  get; set; }
        [Required(ErrorMessage = "Card Number is required.")]
        [Display(Name = "Card Number")]
        [RegularExpression(@"^\d{12,19}$", ErrorMessage = "Invalid card number.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration Month is required.")]
        [Display(Name = "Expiration Month")]
        public string ExpirationMonth { get; set; }

        [Required(ErrorMessage = "Expiration Year is required.")]
        [Display(Name = "Expiration Year")]
        public string ExpirationYear { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [Display(Name = "CVV")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Invalid CVV.")]
        public string CVV { get; set; }

        [Required(ErrorMessage = "Cardholder Name is required.")]
        [Display(Name = "Cardholder Name")]
        public string CardholderName { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Payment Method is required.")]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "You must accept the terms and conditions.")]
        [Display(Name = "Accept Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions.")]
        public bool AcceptTerms { get; set; }
    }
}
