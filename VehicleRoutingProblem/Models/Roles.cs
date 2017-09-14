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
    /// <summary>
    /// مدیریت نقش ها
    /// </summary>
    public class Roles:IdentityRole
    {

    }
}
