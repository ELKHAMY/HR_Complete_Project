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
                    Name = user.Name,
                    Email = user.Email,
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
                    Name = register.Name,
                    UserName = register.UserName,
                    Email = register.Email,
                    ActiveUser = register.ActiveUser
                };
                
                var result = await _userManager.CreateAsync(user, register.Password);

                var roles = GetAllRoles();
                register.Roles = roles.Select(r => new RoleViewModel { Id = r.Id, Name = r.Name }).ToList();

                if (result.Succeeded)
                {
                    if (register.SelectedRole != null)
                    {
                        var role = await _roleManager.FindByNameAsync(register.SelectedRole);
                        if (role != null)
                        {
                            await _userManager.AddToRoleAsync(user, register.SelectedRole);
                        }
                    }
                    return RedirectToAction("Register");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            register.Roles = await _roleManager.Roles.Select(r=>new RoleViewModel { Id  = r.Id,Name = r.Name}).ToListAsync();
            return View(register);
          
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
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Role");
                }
            }
            model.Roles = roles;
            return View("Role");
        }

        #region EditRole


        [HttpGet]
        [Authorize(Permissions.Account.View)]
        public async Task<IActionResult> EditRole(string Id)
        {
            var role = _roleManager.FindByIdAsync(Id).Result;
            
            var model = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return View("Role", model);
        }


        //[HttpGet]
        //public IActionResult EditRole(string Id)
        //{
        //    if (Id == null)
        //        return BadRequest();


        //    var result = GetById(Id);

        //    if (result == null)
        //        return NotFound();

        //    var vmRole = new RoleViewModel
        //    {
        //        Id = result.Id,
        //        Name = result.Name
        //    };
        //    return View(vmRole);
        //}


        //public IdentityRole GetById(string id)
        //{
        //    return _hRcontext.Roles.FirstOrDefault(d => d.Id == id);

        //}
        //[HttpPost]
        //public async Task<IActionResult> EditRole(string id, RoleViewModel model)
        //{
        //    List<IdentityRole> roles = GetAllRoles();
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _roleManager.UpdateAsync(new IdentityRole(model.Name));
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Role");
        //        }
        //    }
        //    model.Roles = roles;
        //    return View(model);
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
