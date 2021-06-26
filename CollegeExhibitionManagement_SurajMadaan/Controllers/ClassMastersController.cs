using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeExhibitionManagement_SurajMadaan.Data;
using CollegeExhibitionManagement_SurajMadaan.Models;
using Microsoft.AspNetCore.Authorization;

namespace CollegeExhibitionManagement_SurajMadaan.Controllers
{
    [Authorize]
    public class ClassMastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassMastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassMasters.ToListAsync());
        }

        // GET: ClassMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMaster = await _context.ClassMasters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classMaster == null)
            {
                return NotFound();
            }

            return View(classMaster);
        }

        // GET: ClassMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClassName,Section,NumberOfStudents")] ClassMaster classMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classMaster);
        }

        // GET: ClassMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMaster = await _context.ClassMasters.FindAsync(id);
            if (classMaster == null)
            {
                return NotFound();
            }
            return View(classMaster);
        }

        // POST: ClassMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClassName,Section,NumberOfStudents")] ClassMaster classMaster)
        {
            if (id != classMaster.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassMasterExists(classMaster.ID))
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
            return View(classMaster);
        }

        // GET: ClassMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMaster = await _context.ClassMasters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (classMaster == null)
            {
                return NotFound();
            }

            return View(classMaster);
        }

        // POST: ClassMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classMaster = await _context.ClassMasters.FindAsync(id);
            _context.ClassMasters.Remove(classMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassMasterExists(int id)
        {
            return _context.ClassMasters.Any(e => e.ID == id);
        }
    }
}
