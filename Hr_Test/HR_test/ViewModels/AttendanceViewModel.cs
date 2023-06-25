using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HR_test.ViewModels
{
    public class AttendanceViewModel
    {
        public int Id { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? Attend { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? InTime { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? OutTime { get; set; }

        [ForeignKey("EmployeePersonalData")]

        public int? EmployeeId { get; set; }

        public int? DepartmentId { get; set; }

        public string Dept_Name { get; set; }
        public string emp_Name { get; set; }

    }
}
