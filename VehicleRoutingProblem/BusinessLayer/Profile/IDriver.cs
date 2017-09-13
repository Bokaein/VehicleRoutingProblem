using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.BusinessLayer.Profile
{
   
interface IDriver:IUser
    {
        [Required]
        [Display(Name = "نوع وسیله نقلیه")]
        string ViehcleName { get; set; }

        [Required]
        [Display(Name = "مدل نقلیه")]
        string Model { get; set; }


    }
}
