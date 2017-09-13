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

        public string ViehcleName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
