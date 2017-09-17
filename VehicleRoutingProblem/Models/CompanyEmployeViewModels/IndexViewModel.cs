using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.CompanyEmployeViewModels
{
    public class IndexViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نام")]
        public string FristName { get; set; }

        
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }


        [Display(Name = "عکس شخصی")]
        public byte[] Image { get; set; }

        [Display(Name = "Roles")]
        public ICollection<string> lstRoles { get; set; }
        
    }
}
