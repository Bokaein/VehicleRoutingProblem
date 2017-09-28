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
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Icon")]
        public byte[] Icon { get; set; }

        [Display(Name = "Site Url")]
        public string SiteUrl { get; set; }

        [NotMapped]
        [Display(Name = "Icon")]
        [FileSize(700240)]
        [FileTypes("jpg")]
        public IFormFile file { get; set; }
        //******
        public ICollection<Users> Users { get; set; }
    }


    
}
