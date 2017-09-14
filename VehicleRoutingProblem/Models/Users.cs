using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VehicleRoutingProblem.Models.AccountViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRoutingProblem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Users : IdentityUser
    {
        public Users()
        {
            if (CompanyInfoID == null)
                CompanyInfo = null;
        }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = "کد ملی باید با صفر شروع شود و {1} رقم باشد", MinimumLength = 10)]
        public string NationalCode { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "عکس شخصی")]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "نام شرکت")]
        public int CompanyInfoID { get; set; }

        [Display(Name = "ارسال اطلاعات کاربری از طریق ایمیل")]
        public bool SentEmail { get; set; }
        [Display(Name = "ارسال اطلاعات کاربری از طریق پیامک")]
        public bool SentSMS { get; set; }

        [NotMapped]
        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "تکرار کلمه عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "پسورد یکسان وارد نشده است")]
        public string ConfirmPassword { get; set; }

        //*********
        public ICollection<Register_AccountType> Register_AccountType { get; set; }
        public ICollection<UserLog> UserLog { get; set; }
        public CompanyInfo CompanyInfo { get; set; }
    }
}
