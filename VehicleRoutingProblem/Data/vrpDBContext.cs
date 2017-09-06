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

        public DbSet<AccountType> tbAccountTypes { get; set; }
        public DbSet<RegisterViewModel> tbRegisters { get; set; }
        public DbSet<Token> tbTokens { get; set; }
    }
}
