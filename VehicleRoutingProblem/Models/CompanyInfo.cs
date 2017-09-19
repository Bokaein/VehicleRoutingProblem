using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models.Validation;

namespace VehicleRoutingProblem.Models
{
    public class CompanyInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Display(Name ="نام شرکت")]
        public string CompanyName { get; set; }
        
        [Display(Name = "آدرس شرکت")]
        public string Address { get; set; }

        [Display(Name = "آیکن شرکت")]
        public byte[] Icon { get; set; }

        [Display(Name = "آدرس سایت شرکت")]
        public string SiteUrl { get; set; }

        [NotMapped]
        [Display(Name = "آیکن شرکت")]
        [FileSize(700240)]
        [FileTypes("jpg")]
        public IFormFile file { get; set; }
        //******
        public ICollection<Users> Users { get; set; }
    }


    
}
