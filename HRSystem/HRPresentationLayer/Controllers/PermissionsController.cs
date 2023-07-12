using Domain;
using Domain.Constants;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRPresentationLayer.Controllers
{

    public class PermissionsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [Authorize(Permissions.Account.View)]
        public async Task<IActionResult> Index(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            var claims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allPermissions = Permissions.PermissionsList().Select(rc => new RolesClaimsViewModel { Value = rc }).ToList();
            foreach (var permission in allPermissions)
            {
                if (claims.Any(c => c == permission.Value))
                    permission.Selected = true;
            }
            return View(new PermissionViewModel
            {
                //automapper
                RoleId = roleId,
                RoleName  = role.Name,
                RolesClaims = allPermissions
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Permissions.Account.Edit)]
        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
                await _roleManager.RemoveClaimAsync(role, claim);
            var SelectedClaims = model.RolesClaims.Where(cr => cr.Selected).ToList();
            foreach (var claim in SelectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim(Helper.Permission, claim.Value));
            return RedirectToAction("Role", "Account");
        }
    }
}
