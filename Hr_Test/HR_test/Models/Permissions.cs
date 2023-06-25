using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

using System;
using System.Collections.Generic;
namespace HR_test
{
    public class Permissions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanView { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        public Group Group { get; set; }
    }
}
