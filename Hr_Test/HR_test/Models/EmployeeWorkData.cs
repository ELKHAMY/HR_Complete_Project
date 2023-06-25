
using HR_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HR_test
{
    
    public partial class EmployeeWorkData
    {
        public int Id { get; set; }
        public DateTime? WorkDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? sallery { get; set; }
        public DateTime? AttandanceDate { get; set; }
        public DateTime? OutDate { get; set; }
        public int? EmployeeID { get; set; }
    
        public virtual EmployeePersonalData EmpolyeePersonalData { get; set; }
    }
}
