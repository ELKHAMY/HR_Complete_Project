using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class SalaryReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
