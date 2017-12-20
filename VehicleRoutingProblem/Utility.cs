using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Data;
using VehicleRoutingProblem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using VehicleRoutingProblem.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IO;
using VehicleRoutingProblem.Controllers;

namespace VehicleRoutingProblem
{




    public static class Utility
    {
        //public static IActionResult RedirectToLocal(string returnUrl)
        //{
        //    //if (Url.IsLocalUrl(returnUrl))
        //    //{
        //    //    ControllerBase a = new ControllerBase();
        //    //    return .Redirect(returnUrl);
        //    //}
        //    //else
        //    //{
        //    //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //    //}
        //}
    }
}
