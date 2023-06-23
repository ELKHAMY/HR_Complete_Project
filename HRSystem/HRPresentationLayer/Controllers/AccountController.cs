using Domain.Models;
using Infrastructure.Data;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRPresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly HRAppDbContext hRcontext;

        public AccountController(HRAppDbContext hRcontext)
        {
            this.hRcontext = hRcontext;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel  register)
        {
            
            var result = new ApplicationUser
            {
                Name = register.Name,
                UserName = register.UserName,
                Email = register.Email,
                ActiveUser = register.ActiveUser
            };
            hRcontext.Add(result);
            hRcontext.SaveChanges();
            return View();
        }
    }
}
