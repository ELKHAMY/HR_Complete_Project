using Domain.Constants;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.IRepsository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class AttendanceController : Controller
    {
        IEmployeePersonalDataRepository employee;
        IDepartmentrep departmentrep;
        IAttendanceRepository attendenceRepo;

        public AttendanceController(IAttendanceRepository attendenceRepo, IEmployeePersonalDataRepository employee, IDepartmentrep departmentrep)
        {
            this.attendenceRepo = attendenceRepo;
            this.employee = employee;
            this.departmentrep = departmentrep;
        }

        [Authorize(Permissions.AttendanceAndDeparture.View)]
        public IActionResult Index()
        {
            List<Attendance> employeeAttendence = attendenceRepo.GetAll().ToList();

            return View(employeeAttendence);
        }

        [Authorize(Permissions.AttendanceAndDeparture.Create)]
        public IActionResult New()
        {
            List<EmployeePersonalData> employees = employee.getall();
            ViewBag.EmpList = employees;

            return View();
        }


        [HttpPost]
        [Authorize(Permissions.AttendanceAndDeparture.Create)]
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
                List<EmployeePersonalData> employees = employee.getall();
                ViewBag.EmpList = employees;

                return View("New", attendance);
            }
        }

        [Authorize(Permissions.AttendanceAndDeparture.Edit)]
        public IActionResult Edit(int id)
        {
            Attendance attendance = attendenceRepo.GetById(id);
            return View(attendance);
        }

        [HttpPost]
        [Authorize(Permissions.AttendanceAndDeparture.Edit)]
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
        [Authorize(Permissions.AttendanceAndDeparture.Delete)]
        public IActionResult Delete(int id)
        {
            attendenceRepo.Delete(id);
            attendenceRepo.Save();
            return RedirectToAction("Index");
        }


        [Authorize(Permissions.AttendanceAndDeparture.View)]


        public IActionResult Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                ModelState.AddModelError("search", "يرجي ادخال اي بيانات");
                return View("Index", attendenceRepo.GetAll());
            }

            var employeeAttendence = attendenceRepo.GetAll()
                        .Where(e => e.EmployeePersonalData.Name.Contains(search) || e.EmployeePersonalData.Department.Name
                        .Contains(search)).ToList();

            if (employeeAttendence.Count == 0)
            {
                ViewBag.Message = "يرجي ادخال اسم موظف صحيح";
            }

            return View("Index", employeeAttendence);
        }

        public IActionResult Search2(DateTime? fromDate, DateTime? toDate)
        {
            if (fromDate > toDate)
            {
                ViewBag.Message = "يرجي ادخال تاريخ صحيح";
                return View("Index", new List<Attendance>());
            }

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            var employeeAttendence = attendenceRepo.GetAll()
                .Where(e => e.EmployeePersonalData.Attendance.Any(a => a.Attend >= fromDate
                && a.Attend <= toDate)).ToList();

            return View("Index", employeeAttendence);
        }
        //public IActionResult Search(string search, DateTime? fromDate, DateTime? toDate)
        //{
        //    if (string.IsNullOrEmpty(search) && fromDate == null && toDate == null)
        //    {
        //        ModelState.AddModelError("search", "يرجي إدخال أي بيانات.");
        //        return View("Index", attendenceRepo.GetAll());
        //    }

        //    var employeeAttendence = attendenceRepo.GetAll();

        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        employeeAttendence = employeeAttendence.Where(e => e.EmployeePersonalData.Name.Contains(search)
        //            || e.EmployeePersonalData.Department.Name.Contains(search));
        //    }

        //    if (fromDate != null && toDate != null )
        //    {
        //        if (fromDate > toDate)
        //        {
        //            ViewBag.Message = "تاريخ الدخول يجب ان يكون قبل الخروج";
        //            return RedirectToAction("Index");
        //        }
        //        employeeAttendence = employeeAttendence.Where(e => e.EmployeePersonalData.Attendance.Any(a => a.Attend >= fromDate
        //            && a.Attend <= toDate));
        //        ViewBag.fromDate = fromDate;
        //        ViewBag.toDate = toDate;
        //    }

        //    if (!employeeAttendence.Any())
        //    {
        //        ViewBag.Message = "لايوجد بيانات , حاول مرة أخري";
        //    }

        //    return View("Index", employeeAttendence);
        //}


    }
}
