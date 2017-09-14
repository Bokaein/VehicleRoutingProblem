using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleRoutingProblem.Data;
using VehicleRoutingProblem.Models.AccountViewModels;

namespace VehicleRoutingProblem.Controllers
{
    public class CompanyInfoes : Controller
    {
        private readonly VRPDbContext _context;

        public CompanyInfoes(VRPDbContext context)
        {
            _context = context;    
        }

        // GET: CompanyInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbCompanyInfos.ToListAsync());
        }

        // GET: CompanyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _context.tbCompanyInfos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (companyInfo == null)
            {
                return NotFound();
            }

            return View(companyInfo);
        }

        // GET: CompanyInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyName,Address,Icon,SiteUrl")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _context.tbCompanyInfos.SingleOrDefaultAsync(m => m.ID == id);
            if (companyInfo == null)
            {
                return NotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyName,Address,Icon,SiteUrl")] CompanyInfo companyInfo)
        {
            if (id != companyInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyInfoExists(companyInfo.ID))
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
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _context.tbCompanyInfos
                .SingleOrDefaultAsync(m => m.ID == id);
            if (companyInfo == null)
            {
                return NotFound();
            }

            return View(companyInfo);
        }

        // POST: CompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyInfo = await _context.tbCompanyInfos.SingleOrDefaultAsync(m => m.ID == id);
            _context.tbCompanyInfos.Remove(companyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyInfoExists(int id)
        {
            return _context.tbCompanyInfos.Any(e => e.ID == id);
        }
    }
}
