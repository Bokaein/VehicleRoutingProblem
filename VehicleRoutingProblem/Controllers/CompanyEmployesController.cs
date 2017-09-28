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
using VehicleRoutingProblem.Models.CompanyEmployeViewModels;
using System.IO;

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
        /// لیست کاربران شرکت به همراه سمت‌هایی که دارند را نشان می‌دهد به جز خود کاربر
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
               if(_SignInManager.IsSignedIn(User))
                {
                    #region join between 3 table : Users,Roles, UserRoles
                    var loginUser = _userManager.GetUserAsync(HttpContext.User);
                    var Users = await _context.Users
                                              .Where(i =>
                                                  i.CompanyInfoID == loginUser.Result.CompanyInfoID &&
                                                  i.Id != loginUser.Result.Id)
                                              .Join(_context.UserRoles, a => a.Id, b => b.UserId, (a, b) => new { b, a })
                                              .Join(_context.Roles, d => d.b.RoleId, f => f.Id,
                                                       (d, f) => new
                                                       {
                                                           RolesName = f.Name,
                                                           LastName = d.a.LastName,
                                                           FirstName = d.a.FristName,
                                                           Id = d.a.Id,
                                                           NationalCode = d.a.NationalCode,
                                                           Image = d.a.Image
                                                       }).ToListAsync();
                    #endregion

                    #region تهیه لیستی از داده‌ها جهت نمایش در ویو
                    var UserGroup = Users.GroupBy(i=>i.Id).Select(i =>i.FirstOrDefault()).ToList();
                    List<IndexViewModel> lstUsers = new List<IndexViewModel>();
                    foreach (var item in UserGroup.AsEnumerable())
                    {
                        IndexViewModel newItem = new IndexViewModel()
                        {
                            FristName = item.FirstName,
                            LastName = item.LastName,
                            Id = item.Id,
                            Image = item.Image,
                            NationalCode = item.NationalCode
                        };
                        newItem.lstRoles = Users.Where(i => i.Id == item.Id).Select(i => i.RolesName).ToList();

                        lstUsers.Add(newItem);
                    } 
                    #endregion
                    
                    return View(lstUsers.OrderBy(i => i.LastName));
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
            Reg.CompanyInfoID = users.CompanyInfoID.Value;
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
                if (users.fileImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await users.fileImage.CopyToAsync(memoryStream);
                        users.Image = memoryStream.ToArray();
                    }
                }
                var user = new Users
                {
                    UserName = users.UserName,
                    Email = users.Email,
                    FristName = users.FristName,
                    LastName = users.LastName,
                    NationalCode = users.NationalCode,
                    PhoneNumber = users.PhoneNumber,
                    Image = users.Image,
                    SentEmail = users.SentEmail,
                    SentSMS = users.SentSMS,

                    //**** افزودن کاربر مربوط به کدام شرکته
                    CompanyInfoID = loginUser.Result.CompanyInfoID
                };
                var result = await _userManager.CreateAsync(user, users.Password);
                
                if (result.Succeeded)
                {
                    //**** افزودن سطح دسترسی تعریف شده در نرم افزار
                    foreach (var item in users.RoleID)
                    {
                        UserRoles rol = new UserRoles()
                        {
                            RoleId = item,
                            UserId = user.Id
                        };
                        _context.UserRoles.Add(rol);
                    }
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