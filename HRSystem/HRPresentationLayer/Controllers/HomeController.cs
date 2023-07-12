using Domain.Models;
using Infrastructure.IRepsository;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOfficialVacationsRepository officialVacations;
        IEmployeePersonalDataRepository employee;
        IAttendanceRepository attendance;
        IDepartmentrep departmentrep;


        public HomeController(ILogger<HomeController> logger, IAttendanceRepository attendance,IEmployeePersonalDataRepository employee , IDepartmentrep departmentrep, IOfficialVacationsRepository officialVacations)
        {
            _logger = logger;
            this.officialVacations = officialVacations;
            this.employee = employee;
            this.attendance = attendance;
            this.departmentrep = departmentrep;
        }

        public IActionResult Index()
        {
            var employees = employee.getall().Count();
            var attend = attendance.GetAll().Count();
            var dept = departmentrep.getall().Count();
            var official = attendance.GetAll().Count();
            var homeVM = new HomeViewModel
            {
                EmpCount = employees,
                AttendCount = attend,
                DeptCount = dept,
                HolidayCount = official
            };

            return View("Index",homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}