using HR_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HR_test
{
 
    
    public partial class Hours
    {
        public int Id { get; set; }
        public int? AddHours { get; set; }
        public int? RemoveHours { get; set; }
    }
}
