using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public class Departmentrep : IDepartmentrep
    {
        HRAppDbContext db;
        public Departmentrep(HRAppDbContext _db) 
        { 
        db = _db;
        }
    
        public void insert(Department department)
        {
            department.Isdeleted = false;
            db.Add(department);
        }

   public List<Department> getall() 
        
        { return db.Department.Where(e=>e.Isdeleted==false).ToList(); }

        public void save()
        {
           db.SaveChanges();
        }
        public Department getbyid(int id)
        {
            return db.Department.FirstOrDefault(e => e.Id == id);
        }
        public void update(int id, Department department)
        {
            Department olddep =  getbyid(id);

            olddep.Name = department.Name;

            
        }

        public void delete(int id)
        {

            Department newmo = getbyid(id);
         

            newmo.Isdeleted = true;

        }

  
    }
}
