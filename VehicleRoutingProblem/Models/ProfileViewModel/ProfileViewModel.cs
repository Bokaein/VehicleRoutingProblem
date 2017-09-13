using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.ProfileViewModel
{
    public class ProfileViewModel
    {

        [Required]
        [Display(Name = "نام")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }


        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { get; set; }

    }
}
