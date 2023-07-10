using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class EmployeePersonalData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string National { get; set; }
        public DateTime? Birthday { get; set; }
        public string NationalId { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public DateTime? WorkDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salary { get; set; }
        public Department Department { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<EmployeeWorkData> EmployeeWorkData { get; set; }



    }
}
