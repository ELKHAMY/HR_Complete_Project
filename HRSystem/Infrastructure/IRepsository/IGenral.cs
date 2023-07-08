using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IGenral
    {
        public Hours GetHours();

        public WeeklyHoliday GetWeeklyHoliday();

        public void updatehour(Hours hours);
        public void updateholi( WeeklyHoliday weeklyHoliday);

        public void save();


    }
}
