using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public class Genral : IGenral
    {
        HRAppDbContext db;
        public Genral(HRAppDbContext db) 
        {
        this.db = db;
        }
        public Hours GetHours()
        {
            return db.Hours.FirstOrDefault(e=>e.Id==1);
        }

        public WeeklyHoliday GetWeeklyHoliday()
        {
            return db.WeeklyHoliday.FirstOrDefault(e => e.Id == 1);
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void updateholi( WeeklyHoliday weeklyHoliday)
        {
            WeeklyHoliday oldwe = GetWeeklyHoliday();

            weeklyHoliday.Day1 = weeklyHoliday.Day1;
            weeklyHoliday.Day2 = weeklyHoliday.Day2;




        }

        public void updatehour( Hours hours)
        {
            Hours oldho = GetHours();

            oldho.AddHours = hours.AddHours;
            oldho.RemoveHours = hours.RemoveHours;
        }
    }
}
