using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Models;
using VehicleRoutingProblem.Models.AccountViewModels;

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
        }
        public DbSet<AccountType> tbAccountTypes { get; set; }
       // public DbSet<RegisterViewModel> tbRegisters { get; set; }
        public DbSet<CompanyInfo> tbCompanyInfos { get; set; }
        public DbSet<Register_AccountType> tbRegister_AccountTypes { get; set; }
        public DbSet<UserLog> tbUserLogs { get; set; }
        public DbSet<VehicleRoutingProblem.Models.Users> Users { get; set; }
    }
}
