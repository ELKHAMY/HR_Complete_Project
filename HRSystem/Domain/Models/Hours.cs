using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Hours
    {
        public int Id { get; set; }
        public int? AddHours { get; set; }
        public int? RemoveHours { get; set; }
    }
}
