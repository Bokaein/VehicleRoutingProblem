using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    public class UserLog
    {
        public int ID { get; set; }
        public int RegisterViewModelID { get; set; }
        public DateTime? LogIn { get; set; }
        public DateTime? LogOut { get; set; }

        //******
        public Users Users { get; set; }
    }
}
