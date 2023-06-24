using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EmployeeWorkData
    {
        public int Id { get; set; }
        public DateTime? WorkDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? salary { get; set; }
        public DateTime? AttandanceDate { get; set; }
        public DateTime? OutDate { get; set; }
        [ForeignKey("EmpolyeePersonalData")]
        public int? EmployeeID { get; set; }

        public virtual EmployeePersonalData EmpolyeePersonalData { get; set; }
    }
}
