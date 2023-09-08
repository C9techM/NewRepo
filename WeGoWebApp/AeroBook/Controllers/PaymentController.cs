using AeroBook.ViewModels.Booking;
using Microsoft.AspNetCore.Mvc;

namespace AeroBook.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(List<BookingViewModel> selectedItems)
        {

            // Redirect to the Index action after saving
            return RedirectToAction("Index", "Payment");

        }

    }
}
