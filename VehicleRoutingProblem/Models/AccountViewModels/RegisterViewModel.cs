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
        public RegisterViewModel()
        {
            if(TokenID==null)
              Token = null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "نام")]
        public string FristName { get; set; }

        [Required]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        

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
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "تلفن همراه")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = "کد ملی باید با صفر شروع شود و {1} رقم باشد", MinimumLength = 10)]
        public string NationalCode { get; set; }

        [Required]
        [Display(Name = "نوع کاربری")]
        public int AccountTypeID { get; set; }
        
        public int? TokenID { get; set; }

        public AccountType AccountType { get; set; }
        public Token Token { get; set; }
    }
}
