using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    public class AccountType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name ="نوع کاربر")]
        public string TypeName { get; set; }

        //*****
        public ICollection<RegisterViewModel> RegisterViewModels { get; set; }

    }
}
