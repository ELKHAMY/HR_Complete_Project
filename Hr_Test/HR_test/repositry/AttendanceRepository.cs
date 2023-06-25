using HR_test.Models;
using HR_test.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HR_test.repositry
{
    public class AttendanceRepository : IAttendanceRepository
    {

        HREntities context;
        public AttendanceRepository(HREntities _context)
        {
            context = _context;
        }


        public IEnumerable<EmployeePersonalData> GetAll()
        {
            return context.EmployeePersonalData
                .Include(a => a.Attendance)
                .Include(a=>a.Department)
                .Include(a=>a.EmployeeWorkData)
                .ToList();
        }

        public void Insert(Attendance attend)
        {
            context.Attendance.Add(attend);
        }

        public void Delete(int id)
        {
            var attend = GetById(id);
            if (attend != null)
            {
                context.Remove(attend);
            }
        }


        public Attendance GetById(int id)
        {
            return context.Attendance
                .Include(a => a.EmployeePersonalData)
                .FirstOrDefault(d => id == d.Id);
        }



        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Attendance attend)
        {
            Attendance attendance = GetById(attend.Id);
            if (attendance != null)
            {
                attendance.Attend = attend.Attend;
                attendance.Departure = attend.Departure;
                attendance.EmployeeId = attend.EmployeeId;
                context.SaveChanges(); // save changes to database
            }
        }
    }
}
