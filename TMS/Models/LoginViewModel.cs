using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMS.Model;

namespace TMS.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*The email field is required."), EmailAddress]
        [Remote(action: "DoesEmailExist", controller: "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*The password field is required.")]
        public string Password { get; set; }
    }
}
