using Microsoft.AspNetCore.Mvc;

namespace AeroBook.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
