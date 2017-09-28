using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VehicleRoutingProblem.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleRoutingProblem.Models.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRoutingProblem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Users : IdentityUser
    {
        public Users()
        {
            
        }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "National Code")]
        [StringLength(10, ErrorMessage = "کد ملی باید با صفر شروع شود و {1} رقم باشد", MinimumLength = 10)]
        public string NationalCode { get; set; }

        [Required]
        [Display(Name = "Frist Name")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", "+ FristName;
            }
        }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        [NotMapped]
        [Display(Name = "Company Name")]
        [FileSize(700240)]
        [FileTypes("jpg")]
        public IFormFile Imagefile { get; set; }

        
        [Display(Name = "Company Name")]
        public int? CompanyInfoID { get; set; }

        [Display(Name = "Send Email")]
        public bool SentEmail { get; set; }
        [Display(Name = "ارسال اطلاعات کاربری از طریق پیامک")]
        public bool SentSMS { get; set; }

        [NotMapped]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "پسورد یکسان وارد نشده است")]
        public string ConfirmPassword { get; set; }
        
        public CompanyInfo CompanyInfo { get; set; }

       
    }
}
