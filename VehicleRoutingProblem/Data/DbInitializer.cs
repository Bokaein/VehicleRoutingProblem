﻿using Microsoft.AspNetCore.Identity;
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
            
            //var user = new Users { UserName = "Amir", Email = "am.bo740@gmail.com" };
            //var result = _userManager.CreateAsync(user, "123456");

        }
        public static void Initialize(Data.VRPDbContext context)
        {
            //method to automatically create the database
            context.Database.EnsureCreated();

            // Look for any students.
            //checks if there are any students in the database, and if not, it assumes the database is new and needs to be seeded with test data.
            
            if (!context.Roles.Any())
            {
                //افزودن انواع کاربران سیستم
                var lstAccount = new Roles[]
                {
                    new Roles(){Name = "مدیر سامانه"},
                    new Roles(){Name = "راننده"},
                    new Roles(){Name = "مشتری"},
                    new Roles(){Name = "توزیع‌کننده"},
                };
                foreach (Roles s in lstAccount)
                {
                    context.Roles.Add(s);
                }
                context.SaveChanges();
            }
            //if(!context.tbCompanyInfos.Any())
            //{
            //    var dd = new CompanyInfo()
            //    {
            //        CompanyName = "Admin"
            //    };
            //    context.tbCompanyInfos.Add(dd);
            //    context.SaveChanges();
            //}
            
            //افزودن کد مدیرسامانه جهت شرکت بهپویان
            //if (!context.tbCompanyInfos.Any())
            //{
            //    CompanyInfo ComInfo = new CompanyInfo() { CompanyName = "بهپویان" ,SiteUrl = "www.Behpouyan.ir"};
            //    context.tbCompanyInfos.Add(ComInfo);
            //    Users Reg = new Users()
            //    {
            //        Address = "پارک علم وفناوری",
            //        CompanyInfo = ComInfo,
            //        FristName = "Amir",
            //        LastName = "Bokaeyan",
            //        UserName = "am.bo740",
            //       // Password = "123456",
            //        Email = "am.bo740@gmail.com",
            //        NationalCode = "0920774768",
            //        PhoneNumber = "09155581868",
            //        PasswordHash = ""

            //    };
            //    context.Users.Add(Reg);


            //    context.SaveChanges();
            //}




        }
    }
}
