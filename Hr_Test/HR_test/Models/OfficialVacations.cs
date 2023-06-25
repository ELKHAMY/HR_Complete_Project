
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HR_test
{
    public class OfficialVacations
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime? Date { get; set; }
    }
}
