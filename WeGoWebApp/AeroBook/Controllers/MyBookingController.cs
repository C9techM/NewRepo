using Microsoft.AspNetCore.Mvc;

namespace AeroBook.Controllers
{
    public class MyBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
