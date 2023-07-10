using static Domain.Helper;
using Domain.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Infrastructure.SeedData
{
    public static class DefaultUser
    {


        //public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        //{
        //    var defaultUser = new ApplicationUser
        //    {
        //        UserName = Helper.UserNameAdmin,
        //        Email = Helper.EmailAdmin,
        //        Name = Helper.NameAdmin,
        //        ActiveUser = true,
        //        EmailConfirmed = true
        //    };

        //    var user =await userManager.FindByEmailAsync(defaultUser.Email);
        //    // create user with own roles
        //    if(user == null)
        //    {
        //        await userManager.CreateAsync(defaultUser, Helper.PasswordAdmin);
        //        await userManager.AddToRolesAsync(defaultUser, new List<string> { Helper.Roles.Admin.ToString() });
        //    }

        //}
        
        
        public static async Task SeedBasicAsync(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = UserNameBasic,
                Email = EmailBasic,
                Name = NameBasic,
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user =await userManager.FindByEmailAsync(defaultUser.Email);
            // create user with own roles
            if(user == null)
            {
                await userManager.CreateAsync(defaultUser, PasswordBasic);
                await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.Basic.ToString() });
            }

        }
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = UserName,
                Email = Email,
                Name = Name,
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user =await userManager.FindByEmailAsync(defaultUser.Email);
            // create user with own roles
            if(user == null)
            {
                await userManager.CreateAsync(defaultUser, Password);
                await userManager.AddToRolesAsync(defaultUser, new List<string> { Roles.SuperAdmin.ToString() });
            }
            await roleManager.SeedClaimsAsync();

        }
 
        public static async Task SeedClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
            //code add permission claims
            var modules = Enum.GetValues(typeof(PermissionModuleName));
            foreach (var module in modules)
            {
                await roleManager.AddPermissionClaims(adminRole, module.ToString());
            }
        }


        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager ,IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionFromModule(module);
            foreach (var permission in allPermissions)
            {
                if(!allClaims.Any(rc=>rc.Type ==Permission && rc.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim(Permission, permission));
                }
            }
        }
    }
}
