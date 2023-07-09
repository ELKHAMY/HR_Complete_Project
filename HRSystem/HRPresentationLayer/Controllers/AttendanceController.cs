using Domain.Models;
using Infrastructure.Data;
using Infrastructure.IRepsository;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class AttendanceController : Controller
    {
        HRAppDbContext context;
        IAttendanceRepository attendenceRepo;

        public AttendanceController(IAttendanceRepository attendenceRepo, HRAppDbContext _context)
        {
            this.attendenceRepo = attendenceRepo;
            context = _context;
        }

        public IActionResult Index()
        {
            List<Attendance> employeeAttendence = attendenceRepo.GetAll().ToList();

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
            if (!ModelState.IsValid)
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

            if (!ModelState.IsValid)
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
        public IActionResult Search(string search, DateTime? fromDate, DateTime? toDate)
        {
            if (string.IsNullOrEmpty(search) && fromDate == null && toDate == null)
            {
                ModelState.AddModelError("search", "At least one field is required.");
                return View("Index", attendenceRepo.GetAll());
            }

            var employeeAttendence = attendenceRepo.GetAll();

            if (!string.IsNullOrEmpty(search))
            {
                employeeAttendence = employeeAttendence.Where(e => e.EmployeePersonalData.Name.Contains(search)
                    || e.EmployeePersonalData.Department.Name.Contains(search));
            }

            if (fromDate != null && toDate != null)
            {
                if (fromDate > toDate)
                {
                    ViewBag.Message = "Please enter a valid date range.";
                    return View("Index", new List<EmployeePersonalData>());
                }
                employeeAttendence = employeeAttendence.Where(e => e.EmployeePersonalData.Attendance.Any(a => a.Attend >= fromDate
                    && a.Attend <= toDate));
                ViewBag.fromDate = fromDate;
                ViewBag.toDate = toDate;
            }

            if (!employeeAttendence.Any())
            {
                ViewBag.Message = "No results found. Please try again with different search criteria.";
            }

            return View("Index", employeeAttendence);
        }

        //public IActionResult Search(string search)
        //{
        //    if (string.IsNullOrEmpty(search))
        //    {
        //        ModelState.AddModelError("search", "These fields are required.");
        //        return View("Index", attendenceRepo.GetAll());
        //    }

        //    var employeeAttendence = attendenceRepo.GetAll()
        //                .Where(e => e.EmployeePersonalData.Name.Contains(search) || e.EmployeePersonalData.Department.Name
        //                .Contains(search)).ToList();

        //    if (employeeAttendence.Count == 0)
        //    {
        //        ViewBag.Message = "Please enter a valid employee name.";
        //    }

        //    return View("Index", employeeAttendence);
        //}

        //public IActionResult Search2(DateTime? fromDate, DateTime? toDate)
        //{
        //    if (fromDate > toDate)
        //    {
        //        ViewBag.Message = "Please enter a valid date.";
        //        return View("Index", new List<EmployeePersonalData>());
        //    }

        //    ViewBag.fromDate = fromDate;
        //    ViewBag.toDate = toDate;

        //    var employeeAttendence = attendenceRepo.GetAll()
        //        .Where(e => e.EmployeePersonalData.Attendance.Any(a => a.Attend >= fromDate
        //        && a.Attend <= toDate)).ToList();

        //    return View("Index", employeeAttendence);
        //}
    }
}
