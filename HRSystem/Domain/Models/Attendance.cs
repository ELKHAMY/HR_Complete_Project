using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime? Attend { get; set; }
        public DateTime? Departure { get; set; }

        [ForeignKey("EmployeePersonalData")]
        public int? EmployeeId { get; set; }

        public EmployeePersonalData? EmployeePersonalData { get; set; }

   
    }
}
