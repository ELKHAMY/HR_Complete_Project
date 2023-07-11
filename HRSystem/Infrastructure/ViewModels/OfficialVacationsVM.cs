using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class OfficialVacationsVM
    {

            [Key]
            public int id { get; set; }
            [Required(ErrorMessage = "الرجاء إدخال الاسم")]
            public string Name { get; set; }

            [Required(ErrorMessage = "الرجاء إدخال التاريخ")]
            [DataType(DataType.Date, ErrorMessage = "الرجاء إدخال تاريخ صحيح")]
            public DateTime Date { get; set; }
       
            public List<OfficialVacations>? offvac { get; set; }
        
    }
}
