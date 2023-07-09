using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class SalaryReportViewModel
    {
        public string Employeename { get; set; }
        public string DepartmentName { get; set; }
        public decimal? sallary { get; set; }
        public int AttendedDay { get; set; }
        public int DeparturedDay { get; set; }
        public decimal OverTimeHours { get; set; }
        public decimal HoursDiscount { get; set; }
        public decimal? totalExtra { get; set; }
        public decimal? totalDiscount { get; set; }
        public decimal? NetSallary { get; set; }
        public int? employeeID { get; set; }
    }
}
