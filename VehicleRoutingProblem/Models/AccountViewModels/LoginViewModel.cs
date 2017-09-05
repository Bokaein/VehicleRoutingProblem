using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [Display(Name = "من را به خاطر بسپار ؟")]
        public bool RememberMe { get; set; }
    }
}
