using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IEmployeerep
    {
        public List<EmployeePersonalData> getall();

        public void insert(EmployeePersonalData emp);
       

        public void update(int id, EmployeePersonalData emp);

        public EmployeePersonalData getbyid(int id);

        public void delete(int id);
        public void save();
    }
}
