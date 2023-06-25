using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class OfficialVacationsVM
    {
       
            public string? Name { get; set; }
            public DateTime? Date { get; set; }
            public List<OfficialVacations>? offvac { get; set; }
        
    }
}
