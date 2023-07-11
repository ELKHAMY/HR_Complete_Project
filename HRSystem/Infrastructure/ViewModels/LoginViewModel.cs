using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class LoginViewModel
    {
      //  [Required(ErrorMessageResourceType = typeof(string),ErrorMessageResourceName ="أدخل البريد الالكتروني")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
    //    [Required(ErrorMessageResourceType = typeof(string), ErrorMessageResourceName = "أدخل الرقم السري")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
