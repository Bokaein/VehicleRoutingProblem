using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    /// <summary>
    /// اطلاعات مربوط به حساب کاربری 
    /// </summary>
    public class RegisterViewModel
    {

        public string Id { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = "کد ملی باید با صفر شروع شود و {1} رقم باشد", MinimumLength = 10)]
        public string NationalCode { get; set; }

        [EmailAddress]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "نام کاربری")]
        public string  UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "پسورد یکسان وارد نشده است")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "نام شرکت")]
        public int CompanyInfoID { get; set; }

        [Display(Name = "ارسال اطلاعات کاربری از طریق ایمیل")]
        public bool SentEmail { get; set; }

        [Display(Name = "ارسال اطلاعات کاربری از طریق پیامک")]
        public bool SentSMS { get; set; }

        [Display(Name = "سمت کاربر")]
        public ICollection<string> RoleID { get; set; }
    }
}
