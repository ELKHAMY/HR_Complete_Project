using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HR_test.ViewModels;

using HR_test.repositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_test.Models;



namespace HR_test.Controllers
{
    public class AttendanceController : Controller
    {
        HREntities context = new HREntities();
        IAttendanceRepository attendenceRepo;

        public AttendanceController(IAttendanceRepository attendenceRepo)
        {
            this.attendenceRepo = attendenceRepo;
        }

        public IActionResult Index()
        {
            List<EmployeePersonalData> employeeAttendence = attendenceRepo.GetAll().ToList();

            return View(employeeAttendence);
        }

        public IActionResult New()
        {
            List<EmployeePersonalData> employees = context.EmployeePersonalData.ToList();
            ViewBag.EmpList = employees;
          
            return View();
        }


        [HttpPost]
        public IActionResult Save(Attendance attendance)
        {
            if (ModelState.IsValid)
            {

                attendenceRepo.Insert(attendance);
                attendenceRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                List<EmployeePersonalData> employees = context.EmployeePersonalData.ToList();
                ViewBag.EmpList = employees;
                
                return View("New", attendance);
            }
        }


        public IActionResult Edit(int id)
        {
            Attendance attendance = attendenceRepo.GetById(id);
            return View(attendance);
        }

        [HttpPost]
        public IActionResult Edit(int id, Attendance attendance)
        {
            if (attendance.EmployeeId == 0)
            {
                ModelState.AddModelError("EmployeeId", "EmployeeId is required");
            }

            if (ModelState.IsValid)
            {
                attendenceRepo.Update(attendance);
                attendenceRepo.Save();

                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            attendenceRepo.Delete(id);
            attendenceRepo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Search(string search)
        {
            var employeeAttendence = attendenceRepo.GetAll()
                .Where(e => e.Name.Contains(search) || e.Department.Name
                .Contains(search)).ToList();

            return View("Index", employeeAttendence);
        }



        public IActionResult Search2(DateTime? fromDate,DateTime? toDate)
        {
            ViewBag.fromDate = fromDate; 
            ViewBag.toDate = toDate;

            var employeeAttendence = attendenceRepo.GetAll()
                .Where(e => e.Attendance.Any(a => a.Attend >= fromDate
                && a.Attend <= toDate)).ToList();

            return View("Index", employeeAttendence);
        }
    }
}