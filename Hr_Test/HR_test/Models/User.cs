using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.RegularExpressions;

using System;
using System.Collections.Generic;
namespace HR_test
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        [ForeignKey("Rule")]
        public int? RuleId { get; set; }

        public Group Group { get; set; }
        public Rules Rule { get; set; }
    }
}
