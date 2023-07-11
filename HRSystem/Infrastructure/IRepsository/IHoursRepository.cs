using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepsository
{
    public interface IHoursRepository
    {
        HoursViewModel add(HoursViewModel model);
        bool update(HoursViewModel model);
        bool delete(int id);
        HoursViewModel GetByID(int id);
        IEnumerable<HoursViewModel> GetALL();

    }
}
