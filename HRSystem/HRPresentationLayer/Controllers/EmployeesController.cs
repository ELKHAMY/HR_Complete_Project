using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    [Authorize(Permissions.Employees.View)]
    public class EmployeesController : Controller
    {
        [Authorize(Permissions.Employees.View)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
