using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Data;
using VehicleRoutingProblem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using VehicleRoutingProblem.Models.AccountViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IO;

namespace VehicleRoutingProblem.Controllers
{
    public class UsersController : Controller
    {
        private readonly VRPDbContext _context;
        private readonly UserManager<Users> _userManager;
       // private readonly RoleManager<Roles> _RoleManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly ILogger _logger;

        public UsersController(
            UserManager<Users> userManager,
            //RoleManager<Roles> RoleManager,
        SignInManager<Users> signInManager, 
            VRPDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;

            _userManager = userManager;
            //_RoleManager = RoleManager;
            _signInManager = signInManager;

            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        // GET: Users
        public async Task<IActionResult> Index(int? CompanyID)
        {
            if(CompanyID == null)
            {
                var vRPDbContext = _context.Users.Include(u => u.CompanyInfo);
                return View(await vRPDbContext.OrderBy(i=>i.FullName).ToListAsync());
            }
            else
            {
                var vRPDbContext = _context.Users.Include(u => u.CompanyInfo);
                return View(await vRPDbContext.Where(i=>i.CompanyInfoID == CompanyID).OrderBy(i => i.FullName).ToListAsync());
            }
        }

        
        /// <summary>
        /// نمایش کامل مشخصات کاربر از جدول 
        /// users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Users/Details/5
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

        /// <summary>
        /// نمایش خلاصه مشخصات کاربر از جدول 
        /// users
        /// از این جدول جهت نمایشی از خلاصه مشخصات کاربر در صفحات دیگر استفاده می کنیم برای این منظور از مدل
        /// RegisterViewModel
        /// استفاده کرده ایم
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Users/Details/5
        public async Task<IActionResult> SummeryDetails(string id,string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.CompanyInfo)
                .SingleOrDefaultAsync(m => m.Id == id);
            //ViewData["IDD"] = id;
            RegisterViewModel Reg = new RegisterViewModel();
            Reg.Id = id;
            Reg.CompanyInfoID = users.CompanyInfoID;
            Reg.Email = users.Email;
            Reg.FristName = users.FristName;
            Reg.LastName = users.LastName;
            Reg.NationalCode = users.NationalCode;
            Reg.PhoneNumber = users.PhoneNumber;
            Reg.UserName = users.UserName;
            Reg.Id = users.Id;
            if (users == null)
            {
                return NotFound();
            }

            return View(Reg);
        }


        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["CompanyInfoID"] = new SelectList(_context.tbCompanyInfos, "ID", "CompanyName");
            ViewData["RoleID"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

   

        /// <summary>
        /// جهت ایجاد مدیر جدید توسط شرکت بهپویان است
        /// لذا سطح دسترسی طرف به اندازه مدیر خواهد بود
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel users)
        {
            if (ModelState.IsValid)
            {

                if (users.fileImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await users.fileImage.CopyToAsync(memoryStream);
                        users.Image = memoryStream.ToArray();
                    }
                }
                
                var user = new Users {
                    UserName = users.UserName,
                    Email = users.Email,
                    FristName = users.FristName,
                    LastName = users.LastName,
                    NationalCode = users.NationalCode,
                    PhoneNumber = users.PhoneNumber,
                    CompanyInfoID = users.CompanyInfoID,
                    SentEmail = users.SentEmail,
                    SentSMS = users.SentSMS,
                    Image = users.Image
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

                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction("Index",null);
                }
            }
            ViewData["CompanyInfoID"] = new SelectList(_context.tbCompanyInfos, "ID", "CompanyName", users.CompanyInfoID);
            ViewData["RoleID"] = new SelectList(_context.Roles, "Id", "Name", users.RoleID);
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> EditSummeryData(string id , string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["CompanyInfoID"] = new SelectList(_context.tbCompanyInfos, "ID", "CompanyName", users.CompanyInfoID);
            return View(users);
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["CompanyInfoID"] = new SelectList(_context.tbCompanyInfos, "ID", "CompanyName", users.CompanyInfoID);
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Address,NationalCode,FristName,LastName,Imagefile,CompanyInfoID,SentEmail,SentSMS,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Users users)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (id != users.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (users.Imagefile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await users.Imagefile.CopyToAsync(memoryStream);
                            users.Image = memoryStream.ToArray();
                        }
                    }
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToLocal(returnUrl);
                   
            }
            ViewData["CompanyInfoID"] = new SelectList(_context.tbCompanyInfos, "ID", "CompanyName", users.CompanyInfoID);
            return View(users);
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

        private bool UsersExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        public async Task<FileStreamResult> GetImage(string FileID)
        {
            var UserInfo = await _context.Users
              .SingleOrDefaultAsync(m => m.Id == FileID);
            Stream stream = new MemoryStream(UserInfo.Image);
            return new FileStreamResult(stream, "image/jpg");
        }

    }
}
