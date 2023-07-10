using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class GeneralSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
