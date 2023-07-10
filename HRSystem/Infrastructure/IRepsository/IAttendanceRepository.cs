using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IAttendanceRepository
    {
        IEnumerable<EmployeePersonalData> GetAll();
        Attendance GetById(int id);
        void Insert(Attendance attend);
        void Update(Attendance attend);
        void Delete(int id);
        void Save();
    }
}
