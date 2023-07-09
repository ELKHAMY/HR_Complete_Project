using Infrastructure.IRepsository;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class SalaryController : Controller
    {
        IEmployeePersonalDataRepository Employeerep;
        IAttendanceRepository Attendancerep;
        IHoursRepository Hoursrep;
        IOfficialVacationsRepository official;


        //-----------

        
        public SalaryController(IEmployeePersonalDataRepository employeerep, IAttendanceRepository attendancerep, IHoursRepository hoursrep, IOfficialVacationsRepository Official)
        {
            this.Employeerep = employeerep;
            this.Attendancerep = attendancerep;
            this.Hoursrep = hoursrep;
            this.official = Official;

        }
        public IActionResult salaryemployee(string search, int year = 0, int month = 0)
        {
            List<SalaryReportViewModel> sallaryReportViewModels = new List<SalaryReportViewModel>();
           
            var attendances = Attendancerep.GetAll();
            var employees = Employeerep.getall();
            var firstDayOfMonth = new DateTime();
            var lastDayOfMonth = new DateTime();
            DateTime date = DateTime.Now;
            if (year <= 0 && month <= 0)
            {
                date = DateTime.Now;
                firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            }
            else
            {
                firstDayOfMonth = new DateTime(year, month, 1);
                lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            }

            foreach (var item in employees)
            {
                SalaryReportViewModel sallaryReportViewModel = new SalaryReportViewModel();

                foreach (var obj in attendances.Where(x => x.EmployeeId == item.Id && x.Attend >= firstDayOfMonth && x.Attend <= lastDayOfMonth))
                {

                    if (obj.Departure.Value.Hour >= item.OutDate.Value.Hour)
                    {
                        sallaryReportViewModel.OverTimeHours += obj.Departure.Value.Hour - item.OutDate.Value.Hour;
                    }
                    else
                    {
                        sallaryReportViewModel.HoursDiscount += item.OutDate.Value.Hour - obj.Departure.Value.Hour;
                    }
                    sallaryReportViewModel.HoursDiscount += obj.Departure.Value.Hour - item.AttandanceDate.Value.Hour;

                    sallaryReportViewModel.Employeename = obj.EmployeePersonalData.Name;
                    sallaryReportViewModel.DepartmentName = obj.EmployeePersonalData.Department.Name;

                    sallaryReportViewModel.sallary = item.salary;
                    sallaryReportViewModel.AttendedDay += 1;
                    var totalDays = 0;
                    if (year <= 0 && month <= 0)
                    {
                        totalDays = WorkDays(date.Year, date.Month);

                    }
                    else
                    {
                        totalDays = WorkDays(year, month);

                    }
                    sallaryReportViewModel.DeparturedDay = totalDays - sallaryReportViewModel.AttendedDay;
                }
                if (sallaryReportViewModel.Employeename != null)
                {
                    // var hoursRepository = new HoursRepository();
                    var hours = Hoursrep.GetALL().FirstOrDefault();
                    decimal? hour = item.salary / 30 / 8;
                    decimal? day = hour * 8;
                    var DeparturedDays = sallaryReportViewModel.DeparturedDay * day;
                    sallaryReportViewModel.totalExtra = (hour * sallaryReportViewModel.OverTimeHours) * hours.addHours;
                    sallaryReportViewModel.totalDiscount = (hour * sallaryReportViewModel.HoursDiscount) * hours.removeHours;

                    sallaryReportViewModel.totalExtra = (decimal)Math.Round((double)sallaryReportViewModel.totalExtra, 2);
                    sallaryReportViewModel.totalDiscount = (decimal)Math.Round((double)(DeparturedDays + sallaryReportViewModel.totalDiscount), 2);
                    sallaryReportViewModel.employeeID = item.Id;
                    sallaryReportViewModel.NetSallary = item.salary + sallaryReportViewModel.totalExtra - sallaryReportViewModel.totalDiscount;
                    sallaryReportViewModel.NetSallary = (decimal)Math.Round((double)sallaryReportViewModel.NetSallary, 2);
                    sallaryReportViewModels.Add(sallaryReportViewModel);

                }




            }


            if (!String.IsNullOrEmpty(search))
            {
                if (sallaryReportViewModels.Where(x => x.Employeename.Contains(search)).Count() == 0)
                {
                    ViewBag.massage = "من فضلك ادخل اسم موظف صالح ";
                }

                return View(sallaryReportViewModels.Where(x => x.Employeename.Contains(search)));
            }
            if (sallaryReportViewModels.Count() == 0)
            {
                ViewBag.CorrectYear = "من فضلك اختر سنه صحيحه ";
            }
            return View(sallaryReportViewModels);


        }


        private int WorkDays(int year, int month)
        {

            var officialVacations = official.GetALL().Where(x => x.date.Value.Year == year && x.date.Value.Month == month);

            int days = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                     .Select(day => new DateTime(year, month, day))
                     .Count(d => d.DayOfWeek != DayOfWeek.Saturday &&
                                 d.DayOfWeek != DayOfWeek.Friday);
            var result = days - officialVacations.Count();

            return result;
        }
        public IActionResult Edit(int id)
        {
            // Retrieve the employee with the specified ID from the database
            var employee = Employeerep.getbyid(id);

            if (employee == null)
            {
                return NotFound();
            }

            // Pass the employee to the view
            return View(employee);
        }
    }
}
