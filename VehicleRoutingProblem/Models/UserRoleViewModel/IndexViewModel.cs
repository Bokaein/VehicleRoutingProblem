using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.UserRoleViewModel
{
    public class IndexViewModel
    {
        [Display(Name = "سمت")]
        public string  RolesName { get; set; }


        [Display(Name ="نام و نام خانوادگی")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        public string UserId{ get; set; }
        public string RoleId { get; set; }

    }
}
