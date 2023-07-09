using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IDepartmentrep
    {
        public List< Department> getall();

        public void insert(Department department);

        public void update(int id,  Department department);

        public Department getbyid(int id);
        public void delete(int id);
        public void save();

    }
}
