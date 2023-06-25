using HR_test.Models;

namespace HR_test.repositry
{
    public interface IAttendanceRepository
    {
        IEnumerable<EmployeePersonalData> GetAll();
      //  List<Attendance> GetByCourseId(int deptId);

        Attendance GetById(int id);
        void Insert(Attendance attend);
        void Update(Attendance attend);
        void Delete(int id);
        void Save();
    }
}
