using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleRoutingProblem.Models.AccountViewModels
{
    public class Token
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name ="نام شرکت طرف قرار داد")]
        public string CompanyName { get; set; }


        [Display(Name = "کد")]
        public string Code { get; set; }

        //******
        public ICollection<RegisterViewModel> RegisterViewModels { get; set; }
    }
}
