using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class AttendanceAndDepartureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
