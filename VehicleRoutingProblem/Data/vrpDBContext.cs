using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models.AccountViewModels;
namespace VehicleRoutingProblem.Data
{
    public class vrpDBContext:DbContext
    {
        public vrpDBContext(DbContextOptions option):base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.AccountViewModels.RegisterViewModel>()
                .HasAlternateKey(c =>new  {c.UserName , c.CompanyInfoID })
                .HasName("uniqe_UserNameAndCompany");
        }
        public DbSet<AccountType> tbAccountTypes { get; set; }
        public DbSet<RegisterViewModel> tbRegisters { get; set; }
        public DbSet<CompanyInfo> tbCompanyInfos { get; set; }
        public DbSet<Register_AccountType> tbRegister_AccountTypes { get; set; }
    }
}
