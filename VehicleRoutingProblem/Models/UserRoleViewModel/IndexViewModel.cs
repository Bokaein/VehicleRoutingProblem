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
        [Display(Name = "Role Name")]
        public string  RolesName { get; set; }


        [Display(Name ="Last Name / First Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string UserId{ get; set; }
        public string RoleId { get; set; }

    }
}
