using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    public class Register_AccountType
    {
        public int ID { get; set; }

        public int AccountTypeID { get; set; }
        public int RegisterViewModelID { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
        public AccountType AccountType { get; set; }
    }
}
