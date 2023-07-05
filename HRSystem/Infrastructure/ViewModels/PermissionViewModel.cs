using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class PermissionViewModel
    {
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public List<RolesClaimsViewModel> RolesClaims { get; set; } = new List<RolesClaimsViewModel>();
    }

    public class RolesClaimsViewModel
    {
        public string Value { get; set; } = string.Empty;
        public bool Selected { get; set; }
    }

}
