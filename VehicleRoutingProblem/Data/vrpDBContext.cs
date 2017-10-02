using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Models;
using VehicleRoutingProblem.Models.AccountViewModels;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleRoutingProblem.Data
{
    public class VRPDbContext : IdentityDbContext<Users>
    {
        public VRPDbContext(DbContextOptions<VRPDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Models.Users>()
                .HasAlternateKey(c => new { c.UserName, c.CompanyInfoID })
                .HasName("uniqe_UserNameAndCompany");
            builder.Entity<Users>()
                .HasOne(p => p.CompanyInfo)
                .WithMany(b => b.Users)
                .HasForeignKey(p => p.CompanyInfoID)
                .HasConstraintName("ForeignKey_Users_CompanyInfo")
                .IsRequired(false);
        }
        // public DbSet<RegisterViewModel> tbRegisters { get; set; }
        public DbSet<CompanyInfo> tbCompanyInfos { get; set; }
        public DbSet<VehicleRoutingProblem.Models.Roles> Roles { get; set; }
        public DbSet<VehicleRoutingProblem.Models.UserRoles> UserRoles { get; set; }
        public DbSet<VehicleRoutingProblem.Models.Users> Users { get; set; }
        //public DbSet<VehicleRoutingProblem.Models.Roles> Roles { get; set; }
        //public DbSet<VehicleRoutingProblem.Models.UserRoles> UserRoles { get; set; }
    }
}
