using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models;
using VehicleRoutingProblem.Models.AccountViewModels;
namespace VehicleRoutingProblem.Data
{
    public static class DbInitializer
    {
        public static void CreatNewManager()
        {
            //UserManager<Users> _userManager = new UserManager<Users>(null);
            //var user = new Users { UserName = "Amir", Email = "am.bo740@gmail.com" };
            //var result = _userManager.CreateAsync(user, "123456");
        }
        public static void Initialize(Data.VRPDbContext context)
        {
            //method to automatically create the database
            context.Database.EnsureCreated();

            // Look for any students.
            //checks if there are any students in the database, and if not, it assumes the database is new and needs to be seeded with test data.
            if (!context.tbAccountTypes.Any())
            {
                //افزودن انواع کاربران سیستم
                var lstAccount = new AccountType[]
                {
                    new AccountType(){TypeName = "مدیر سامانه"},
                    new AccountType(){TypeName = "راننده"},
                    new AccountType(){TypeName = "مشتری"},
                    new AccountType(){TypeName = "متقاضی"},
                };
                foreach (AccountType s in lstAccount)
                {
                    context.tbAccountTypes.Add(s);
                }
                context.SaveChanges();
            }

            //افزودن کد مدیرسامانه جهت شرکت بهپویان
            if (!context.tbCompanyInfos.Any())
            {
                CompanyInfo ComInfo = new CompanyInfo() { CompanyName = "بهپویان" ,SiteUrl = "www.Behpouyan.ir"};
                context.tbCompanyInfos.Add(ComInfo);
                Users Reg = new Users()
                {
                    Address = "پارک علم وفناوری",
                    CompanyInfo = ComInfo,
                    FristName = "Amir",
                    LastName = "Bokaeyan",
                    UserName = "am.bo740",
                   // Password = "123456",
                    Email = "am.bo740@gmail.com",
                    NationalCode = "0920774768",
                    PhoneNumber = "09155581868",
                    PasswordHash = ""
                    
                };
                context.Users.Add(Reg);
                context.tbRegister_AccountTypes.Add(new Register_AccountType()
                {
                    AccountTypeID = 1,
                    Users = Reg
                });



                context.SaveChanges();
            }

            


        }
    }
}
