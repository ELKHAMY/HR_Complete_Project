using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HR_test.Models
{
    public class HREntities : DbContext
    {
        public HREntities() : base()
        {

        }

        public HREntities(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Permissions> Permission { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeWorkData> EmployeeWorkData { get; set; }
        public DbSet<EmployeePersonalData> EmployeePersonalData { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<OfficialVacations> OfficialVacations { get; set; }
        public DbSet<Hours> Hours { get; set; }
        public DbSet<Rules> Rules { get; set; }
        public DbSet<WeeklyHoliday> WeeklyHoliday { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-75M4UJ7;Initial Catalog=HRFINALISA;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
