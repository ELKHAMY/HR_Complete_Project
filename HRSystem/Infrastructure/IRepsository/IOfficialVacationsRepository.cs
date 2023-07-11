using Domain.Models;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IOfficialVacationsRepository
    {
        List<OfficialVacations> GetAll();

        OfficialVacations GetById(int id);
        void Create(OfficialVacations vac);
        void Save();
        void Delete(int id);
        public void update(int id, OfficialVacations v);

    }
}
