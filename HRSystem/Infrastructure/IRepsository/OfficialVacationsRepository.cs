using Domain.Models;
using Infrastructure.Data;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.IRepsository.OfficialVacationsRepository;

namespace Infrastructure.IRepsository
{
  
     public class OfficialVacationsRepository : IOfficialVacationsRepository
     {
            HRAppDbContext context;

            public OfficialVacationsRepository(HRAppDbContext context)
            {
                this.context = context;
            }

            public void Create(OfficialVacations vac)
            {

                context.Add(vac);
            }

            public List<OfficialVacations> GetAll()
            {
                return context.OfficialVacations.ToList();
            }

            public OfficialVacations GetById(int id)
            {
                return context.OfficialVacations.FirstOrDefault(e => e.Id == id);

            }

            public void Save()
            {
                context.SaveChanges();
            }
            public void Delete(int id)
            {
                OfficialVacations delvac = GetById(id);
                context.OfficialVacations.Remove(delvac);
            }
            public void update(int id, OfficialVacations v)
            {
                OfficialVacations vo = GetById(id);
                vo.Name = v.Name;

                vo.Date = v.Date;



            }



        }
}
