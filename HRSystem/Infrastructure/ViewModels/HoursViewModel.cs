using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class HoursViewModel
    {

        [Key]
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "  من فضلك ادخل  عددالساعات الاضافة")]
        public int? addHours { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "من فضلك ادخل  عدد الساعات الحذف")]
        public int? removeHours { get; set; }
    }
}
