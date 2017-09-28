using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models.Validation;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    /// <summary>
    /// اطلاعات مربوط به حساب کاربری 
    /// </summary>
    public class RegisterViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        
        [NotMapped]
        [Display(Name = "Image")]
        [FileSize(700240)]
        [FileTypes("jpg")]
        public IFormFile fileImage { get; set; }


        [Required]
        [Display(Name = "Frist Name")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "National Code")]
        [StringLength(10, ErrorMessage = "کد ملی باید با صفر شروع شود و {1} رقم باشد", MinimumLength = 10)]
        public string NationalCode { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "User Name")]
        public string  UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "پسورد یکسان وارد نشده است")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public int CompanyInfoID { get; set; }

        [Display(Name = "Send Email")]
        public bool SentEmail { get; set; }

        [Display(Name = "Send SMS")]
        public bool SentSMS { get; set; }

        [Display(Name = "Role")]
        public ICollection<string> RoleID { get; set; }
    }
}
