using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OfficialVacations
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Day { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}
