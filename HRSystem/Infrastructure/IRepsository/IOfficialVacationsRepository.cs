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
        OfficialVacationsViewModel add(OfficialVacationsViewModel model);
        bool update(OfficialVacationsViewModel model);
        bool delete(int id);
        OfficialVacationsViewModel GetByID(int id);
        IEnumerable<OfficialVacationsViewModel> GetALL();

    }
}
