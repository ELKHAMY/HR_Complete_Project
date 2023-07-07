using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class RegisterViewModel
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        public bool ActiveUser { get; set; }

        public string SelectedRole { get; set; }
        //  public string RoleName { get; set; }
        public List<RoleViewModel>? Roles { get; set; }
      //  public List<ApplicationUser>? Users{ get; set; }
        public List<UserRoleViewModel>? UserswithRole{ get; set; }



    }
    public class UserRoleViewModel
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string roleName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
