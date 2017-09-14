using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Data;
using VehicleRoutingProblem.DataAccesslayer;

using VehicleRoutingProblem.BusinessLayer.Profile;

namespace VehicleRoutingProblem.DataAccesslayer
{
    public class Driver : User, IDriver
    {
        public Driver(VRPDbContext context) : base(context)
        {
        }

        public string ViehcleName { get; set ; }
        public string Model { get ; set ; }
    }
}
