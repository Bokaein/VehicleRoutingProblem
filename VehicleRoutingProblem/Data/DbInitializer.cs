using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRoutingProblem.Models.AccountViewModels;
namespace VehicleRoutingProblem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Data.vrpDBContext context)
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
                var lstToken = new CompanyInfo[]
                {
                    new CompanyInfo(){CompanyName = "بهپویان"},
                };
                foreach (CompanyInfo s in lstToken)
                {
                    context.tbCompanyInfos.Add(s);
                }
                context.SaveChanges();
            }


        }
    }
}
