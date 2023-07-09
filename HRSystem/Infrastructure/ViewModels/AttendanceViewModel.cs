using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class AttendanceViewModel
    {

        [Key]
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " من فضلك  ادخل موعد الحضور ")]
        public DateTime? attend { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  موعد الانصراف ")]
        public DateTime? Departure { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  اسم الموظف ")]
        public string employeeName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل القسم ")]
        public string department { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل الموظف ")]
        public int? employeeId { get; set; }
    }
}
