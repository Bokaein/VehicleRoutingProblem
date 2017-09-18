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

namespace VehicleRoutingProblem.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly VRPDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _SignInManager;
        public UserRolesController(VRPDbContext context,
              UserManager<Users> userManager,
            SignInManager<Users> SignInManager
           /* ILogger logger*/)
        {
            _context = context;
            _userManager = userManager;
            _SignInManager = SignInManager;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            try
            {
                if (_SignInManager.IsSignedIn(User))
                {
                    var loginUser = _userManager.GetUserAsync(HttpContext.User);
                    var Users = await _context.Users.Where(i =>
                    i.CompanyInfoID == loginUser.Result.CompanyInfoID &&
                    i.Id != loginUser.Result.Id).ToListAsync();
                    //return View(Users);

                    var URs = await _context.Users.Where(q => q.CompanyInfoID == loginUser.Result.CompanyInfoID)
                        .Join(_context.UserRoles,
             a => a.Id,
             b => b.UserId,
             (a, b) => new { b, a }).Join(_context.Roles,
             d => d.b.RoleId,
             f => f.Id,
             (d, f) => new Models.UserRoleViewModel.IndexViewModel { RolesName = f.Name, UserName = d.a.LastName, UserId = d.a.Id, RoleId = f.Id }).ToListAsync();

                    return View(URs);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        // GET: UserRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles
                .SingleOrDefaultAsync(m => m.UserId == id);
            if (userRoles == null)
            {
                return NotFound();
            }

            return View(userRoles);
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            //ViewData["CompanyInfoID"] = new SelectList(_context.tbCompanyInfos, "ID", "CompanyName");
            ViewData["RoleID"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] UserRoles userRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userRoles);
                    var result = await _context.SaveChangesAsync();


                }
                ViewData["RoleID"] = new SelectList(_context.Roles, "Id", "Name");
                ViewData["UserID"] = new SelectList(_context.Users, "Id", "FullName");
                //   return View(userRoles);
                return RedirectToAction("Index", null);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles.SingleOrDefaultAsync(m => m.UserId == id);
            if (userRoles == null)
            {
                return NotFound();
            }
            return View(userRoles);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,RoleId")] UserRoles userRoles)
        {
            if (id != userRoles.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRolesExists(userRoles.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(userRoles);
        }

        // GET: UserRoles/Delete/5
        public async Task<IActionResult> Delete(string UserId,String RoleId)
        {
            if (UserId == null || UserId == RoleId)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles
                .SingleOrDefaultAsync(m => m.UserId == UserId && m.RoleId==RoleId);
            if (userRoles == null)
            {
                return NotFound();
            }

            return View(userRoles);
        }

        //POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("UserId,RoleId")] UserRoles userRoles)
        {
            _context.UserRoles.Remove(userRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        private bool UserRolesExists(string id)
        {
            return _context.UserRoles.Any(e => e.UserId == id);
        }
    }
}
