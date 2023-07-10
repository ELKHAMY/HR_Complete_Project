using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HRAppDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public HRAppDbContext(DbContextOptions<HRAppDbContext> options): base(options)
        {            
        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Hours> Hours { get; set; }
        public DbSet<EmployeePersonalData> EmployeePersonalData { get; set; }
        public DbSet<EmployeeWorkData> EmployeeWorkData { get; set; }
        public DbSet<OfficialVacations> OfficialVacations { get; set; }
        public DbSet<WeeklyHoliday> WeeklyHoliday { get; set; }
       
    }
}
