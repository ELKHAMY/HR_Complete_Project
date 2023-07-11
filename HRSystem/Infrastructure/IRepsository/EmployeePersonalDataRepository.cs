using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public class EmployeePersonalDataRepository : IEmployeePersonalDataRepository
    {
        HRAppDbContext db;


        public EmployeePersonalDataRepository(HRAppDbContext _db) 
        {
        
            this.db = _db;  
        
        }

        //public static dynamic GetALL()
        //{
        //    throw new NotImplementedException();
        //}

        public void delete(int id)
        {

            EmployeePersonalData newmo = getbyid(id);


            newmo.Isdeleted = true;

        }

        public List<EmployeePersonalData> getall()
        {
            return db.EmployeePersonalData.Where(e=> e.Isdeleted==false).ToList();
        }

        public EmployeePersonalData getbyid(int id)
        {
            return db.EmployeePersonalData.FirstOrDefault(e => e.Id == id);
        }

        public void insert(EmployeePersonalData emp)
        {
            db.EmployeePersonalData.Add(emp);
        }

        public void save()
        {
           db.SaveChanges();
        }

        public void update(int id, EmployeePersonalData emp)
        {
            EmployeePersonalData oldemp = getbyid(id);

            oldemp.Name = emp.Name;
            oldemp.Address=emp.Address;
            oldemp.Phone=emp.Phone;
            oldemp.Gender = emp.Gender;
            oldemp.National = emp.National;
            oldemp.Birthday = emp.Birthday;
            oldemp.NationalId=emp.NationalId;
            oldemp.DepartmentId=emp.DepartmentId;
            oldemp.WorkDate=emp.WorkDate;
            oldemp.salary=emp.salary;
            oldemp.Attendance=emp.Attendance;
            oldemp.OutDate=emp.OutDate;
        }
    }
}
