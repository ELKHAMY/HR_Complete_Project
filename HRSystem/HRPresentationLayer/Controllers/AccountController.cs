using Domain.Constants;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Linq;

namespace HRPresentationLayer.Controllers
{
    [Authorize(Permissions.Account.View)]

    public class AccountController : Controller
    {
        HRAppDbContext _hRcontext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #region CTOR
        public AccountController(HRAppDbContext hRcontext,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _hRcontext = hRcontext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        #endregion

        #region All_Actions
        [Authorize(Permissions.Account.View)]
        public IActionResult Index()
        {
            var userss = new RegisterViewModel();
           // userss.Users = GetAllUsers().Result;
            return View(userss);
        }

        #region business logic will moved soon
        public List<IdentityRole> GetAllRoles() => _roleManager.Roles.ToList();
        public async Task<List<ApplicationUser>> GetAllUsers() => await _userManager.Users.ToListAsync();


        #endregion

        #region Register

        [HttpGet]
        [Authorize(Permissions.Account.View)]
        public async Task<IActionResult> Register()
        {
            var roles = await _roleManager.Roles.Select(r => new RoleViewModel { Id = r.Id, Name = r.Name }).ToListAsync();
            var users = await _userManager.Users.ToListAsync();

            var UserRoleVM = new List<UserRoleViewModel>();
            foreach (var user in users)
            {
                var rolesusers = await _userManager.GetRolesAsync(user);
                UserRoleVM.Add(new UserRoleViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.PasswordHash,
                    roleName = rolesusers.FirstOrDefault()
                });
                
            }
            var viewModel = new RegisterViewModel();
            viewModel.UserswithRole = UserRoleVM;
            viewModel.Roles = roles;
          
            return View(viewModel);
        }



        [HttpPost]
        [Authorize(Permissions.Account.Create)]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {

            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser
                {
                    Id = register.Id,
                    Name = register.Name,
                    UserName = register.UserName,
                    Email = register.Email,
                    ActiveUser = register.ActiveUser
                };
                if (user.Id == null)
                { // Add
                    user.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(user, register.Password);

                    register.Roles =  _roleManager.Roles.Select(r => new RoleViewModel { Id = r.Id, Name = r.Name }).ToList();
                    if (result.Succeeded && (await _roleManager.FindByNameAsync(register.SelectedRole) != null))
                    {
                        await _userManager.AddToRoleAsync(user, register.SelectedRole);
                        return RedirectToAction("Register");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                { // Update
                    var userUpdate = await _userManager.FindByIdAsync(user.Id);
                    if (userUpdate != null && userUpdate.Id == register.Id)
                    {
                        //  userUpdate.Id = register.Id;
                        userUpdate.Name = register.Name;
                        userUpdate.UserName = register.UserName;
                        userUpdate.Email = register.Email;
                        userUpdate.ActiveUser = register.ActiveUser;

                        var result = await _userManager.UpdateAsync(userUpdate);
                        if (result.Succeeded)
                        {
                            var oldRole = await _userManager.GetRolesAsync(userUpdate);
                            await _userManager.RemoveFromRolesAsync(userUpdate, oldRole);
                            await _userManager.AddToRoleAsync(userUpdate, register.SelectedRole);
                        }
                     }
                 }
                    return RedirectToAction("Register", "Account");
                }
            return RedirectToAction("Register", "Account");
        }
          

        #endregion

    
        #region Roles
        [HttpGet]
        [Authorize(Permissions.Account.View)]
        public IActionResult Role()
        {
            var roles = GetAllRoles();
            var model = new RoleViewModel
            {
                Roles = roles
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Permissions.Account.Create)]
        public async Task<IActionResult> Role(RoleViewModel model)
        {
            var roles = GetAllRoles();
            if (model.Id == null && model.Name != null)
            {// Add
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Role));
                }
            }
            else
            { // Update
                var roleUpdate = await _roleManager.FindByIdAsync(model.Id);
                roleUpdate.Id = model.Id;
                roleUpdate.Name = model.Name;
                var ResultUpdate = await _roleManager.UpdateAsync(roleUpdate);
                if (ResultUpdate.Succeeded)
                {
                    return RedirectToAction("Role");
                }
                return RedirectToAction("Role");
            }
            model.Roles = roles;
            return View("Role",model);
        }

        #region EditRole


        //[HttpGet]
        //[Authorize(Permissions.Account.View)]
        //public async Task<IActionResult> EditRole(string Id)
        //{
        //    var role = _roleManager.FindByIdAsync(Id).Result;
            
        //    var model = new RoleViewModel
        //    {
        //        Id = role.Id,
        //        Name = role.Name
        //    };
        //    return View("Role", model);
        //}


        #endregion

        #endregion



        #region Login and logout
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usermodel = await _userManager.FindByEmailAsync(model.Email);
                if (usermodel != null)
                {
                    //found username
                    var result =await _signInManager.PasswordSignInAsync(usermodel, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", "error");
                    }
                }
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Logout(LoginViewModel model)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }

        #endregion

        #endregion
    }
}
