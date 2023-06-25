
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HR_test
{
    public class Rules
    {
        public int Id { get; set; }
        public string RuleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
