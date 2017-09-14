using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Data;
using VehicleRoutingProblem.Models;

namespace VehicleRoutingProblem.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly VRPDbContext _context;

        public UserRolesController(VRPDbContext context)
        {
            _context = context;    
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRoles.ToListAsync());
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
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] UserRoles userRoles)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(userRoles);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(userRoles);
            var ur = new UserRoles();
            ur.UserId = _context.Users.FirstOrDefault().Id;
            ur.RoleId = _context.Roles.FirstOrDefault().Id;
            if (ModelState.IsValid)
            {
                _context.Add(ur);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userRoles);
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
        public async Task<IActionResult> Delete(string id)
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

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userRoles = await _context.UserRoles.SingleOrDefaultAsync(m => m.UserId == id);
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
