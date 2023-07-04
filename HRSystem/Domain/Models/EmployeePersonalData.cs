using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class EmployeePersonalData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression("^(011|012|010)\\d{8}$", ErrorMessage = "يجب ان تبدأ الارقام ب 011 او 012 او 010")]
        public string Phone { get; set; }
       
        [RegularExpression("^(رجل|امراة)$" , ErrorMessage = "الرجاء ادخال رجل او امراة")]
        public string Gender { get; set; }
        public string National { get; set; }

        [AtLeast20YearsAgo]

        public DateTime? Birthday { get; set; }
        [RegularExpression("^\\d{11}$" , ErrorMessage = "يجب ان يحتوي الرقم القومي علي 11 ارقام")]    
        public string NationalId { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [After2008]
        public DateTime? WorkDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        [RegularExpression("^[0-9]+$" , ErrorMessage = "ادخل ارقام فقط")]
        public decimal? salary { get; set; }
        public DateTime? AttandanceDate { get; set; }
        public DateTime? OutDate { get; set; }
        public bool Isdeleted { get; set; }
        public Department? Department { get; set; }
        public ICollection<Attendance>? Attendance { get; set; }



    }
}
