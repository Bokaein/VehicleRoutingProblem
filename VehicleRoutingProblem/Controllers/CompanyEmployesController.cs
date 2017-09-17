using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleRoutingProblem.Data;
using Microsoft.AspNetCore.Identity;
using VehicleRoutingProblem.Models;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace VehicleRoutingProblem.Controllers
{
    /// <summary>
    /// در این کنترلر اضافه کردن، ویرایش کردن و حذف کردن کارمندان توسط مدیر هر سامانه 
    /// صورت می گیرد این کنترلر شباهت های بسیاری به کنترلر مربوط به تعریف کاربران توسط شرکت بهپویان یعنی 
    /// UsersController
    /// دارد
    /// </summary>
    public class CompanyEmployesController : Controller
    {
        private readonly VRPDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _SignInManager;
       // private readonly ILogger _logger;
        public CompanyEmployesController(VRPDbContext context,
            UserManager<Users> userManager, 
            SignInManager<Users> SignInManager
           /* ILogger logger*/)
        {
            _context = context;
            _userManager = userManager;
            _SignInManager = SignInManager;
          //  _logger = logger;
        }


        // GET: CompanyEmployes
        /// <summary>
        /// لیست کاربران شرکت را نشان می‌دهد به جز خود کاربر
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
               if(_SignInManager.IsSignedIn(User))
                {
                    var loginUser = _userManager.GetUserAsync(HttpContext.User);
                    var Users = await _context.Users.Where(i => 
                    i.CompanyInfoID == loginUser.Result.CompanyInfoID &&
                    i.Id != loginUser.Result.Id).ToListAsync();
                       return View( Users);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
            
        }

        // GET: CompanyEmployes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.CompanyInfo)
                .SingleOrDefaultAsync(m => m.Id == id);
            ViewData["IDD"] = id;
            RegisterViewModel Reg = new RegisterViewModel();
            Reg.CompanyInfoID = users.CompanyInfoID;
            Reg.Email = users.Email;
            Reg.FristName = users.FristName;
            Reg.LastName = users.LastName;
            Reg.NationalCode = users.NationalCode;
            Reg.PhoneNumber = users.PhoneNumber;
            Reg.UserName = users.UserName;

            if (users == null)
            {
                return NotFound();
            }

            return View(Reg);
        }

        // GET: CompanyEmployes/Create
        public ActionResult Create()
        {
            ViewData["RoleID"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: CompanyEmployes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel users)
        {
            if (ModelState.IsValid)
            {
                var loginUser = _userManager.GetUserAsync(HttpContext.User);
                var user = new Users
                {
                    UserName = users.UserName,
                    Email = users.Email,
                    FristName = users.FristName,
                    LastName = users.LastName,
                    NationalCode = users.NationalCode,
                    PhoneNumber = users.PhoneNumber,

                    SentEmail = users.SentEmail,
                    SentSMS = users.SentSMS,

                    //**** افزودن کاربر مربوط به کدام شرکته
                    CompanyInfoID = loginUser.Result.CompanyInfoID
                };
                var result = await _userManager.CreateAsync(user, users.Password);
                
                if (result.Succeeded)
                {
                    //**** افزودن سطح دسترسی تعریف شده در نرم افزار
                    UserRoles rol = new UserRoles()
                    {
                        RoleId = users.RoleID.FirstOrDefault(),
                        UserId = user.Id
                    };
                   _context.UserRoles.Add(rol);
                    await _context.SaveChangesAsync();
                    


                    //**** خط زیر خطا میداد فعلا حذف کردم
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //_logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction("Index", null);
                }
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "Id", "Name",users.RoleID);
            return View(users);
        }

        // GET: CompanyEmployes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyEmployes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.CompanyInfo)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var users = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}