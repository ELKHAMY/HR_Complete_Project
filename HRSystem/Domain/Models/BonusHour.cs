using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class BonusHour
    {
        public int Id { get; set; }
        public int? Hours { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("EmployeePersonalData")]
        public int EmployeeId { get; set; }

        public EmployeePersonalData? EmployeePersonalData { get; set; }
    }
}
