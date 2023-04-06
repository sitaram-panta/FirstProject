﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstProject.Data;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class CollegesController : Controller
    {
        private readonly StudentDbContext _context;

        public CollegesController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Colleges
        public async Task<IActionResult> Index()
        {
              return _context.College != null ? 
                          View(await _context.College.ToListAsync()) :
                          Problem("Entity set 'StudentDbContext.College'  is null.");
        }

        // GET: Colleges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.College == null)
            {
                return NotFound();
            }

            var college = await _context.College
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // GET: Colleges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollegeId,Name,Address,Phone")] College college)
        {
            if (ModelState.IsValid)
            {
                _context.Add(college);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(college);
        }

        // GET: Colleges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.College == null)
            {
                return NotFound();
            }

            var college = await _context.College.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollegeId,Name,Address,Phone")] College college)
        {
            if (id != college.CollegeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(college);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeExists(college.CollegeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(college);
        }

        // GET: Colleges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.College == null)
            {
                return NotFound();
            }

            var college = await _context.College
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.College == null)
            {
                return Problem("Entity set 'StudentDbContext.College'  is null.");
            }
            var college = await _context.College.FindAsync(id);
            if (college != null)
            {
                _context.College.Remove(college);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeExists(int id)
        {
          return (_context.College?.Any(e => e.CollegeId == id)).GetValueOrDefault();
        }
    }
}
