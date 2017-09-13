using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models;
using VehicleRoutingProblem.Models.ProfileViewModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleRoutingProblem.BusinessLayer.Profile
{
    public interface IUser : IDisposable

    {
        [Required]
        [Display(Name = "نام")]
         string FristName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
         string LastName { get; set; }


        [EmailAddress]
        [Display(Name = "ایمیل")]
         string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "تلفن همراه")]
         string PhoneNumber { get; set; }

     
       void GetUserByID(int UserId);
       
      
        void Save();
    }
}
