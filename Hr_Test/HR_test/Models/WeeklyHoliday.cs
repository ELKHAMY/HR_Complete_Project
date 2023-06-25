
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HR_test
{
    public class WeeklyHoliday
    {
        public int Id { get; set; }
        public string Day1 { get; set; }
        public string? Day2 { get; set; }
    }
}
