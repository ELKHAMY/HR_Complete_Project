using Domain.Models;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IAttendanceRepository
    {


        public IEnumerable<Attendance> GetAll();
        Attendance GetById(int id);
        void Insert(Attendance attend);
        void Update(Attendance attend);
        void Delete(int id);
        void Save();
    }



    //AttendanceViewModel add(AttendanceViewModel model);
    //bool update(AttendanceViewModel model);
    //bool delete(int id);
    //AttendanceViewModel GetByID(int id);
    //IEnumerable<AttendanceViewModel> GetALL(string search);

}

