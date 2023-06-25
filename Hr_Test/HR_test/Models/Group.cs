using HR_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HR_test

{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Permissions> Permissions { get; set; }
    }
}
