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
    public class ExhibitionCoordinatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExhibitionCoordinatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExhibitionCoordinators
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExhibitionCoordinators.Include(e => e.ClassMaster);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExhibitionCoordinators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionCoordinator = await _context.ExhibitionCoordinators
                .Include(e => e.ClassMaster)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exhibitionCoordinator == null)
            {
                return NotFound();
            }

            return View(exhibitionCoordinator);
        }

        // GET: ExhibitionCoordinators/Create
        public IActionResult Create()
        {
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName");
            return View();
        }

        // POST: ExhibitionCoordinators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClassMasterID,Name")] ExhibitionCoordinator exhibitionCoordinator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibitionCoordinator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName", exhibitionCoordinator.ClassMasterID);
            return View(exhibitionCoordinator);
        }

        // GET: ExhibitionCoordinators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionCoordinator = await _context.ExhibitionCoordinators.FindAsync(id);
            if (exhibitionCoordinator == null)
            {
                return NotFound();
            }
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName", exhibitionCoordinator.ClassMasterID);
            return View(exhibitionCoordinator);
        }

        // POST: ExhibitionCoordinators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClassMasterID,Name")] ExhibitionCoordinator exhibitionCoordinator)
        {
            if (id != exhibitionCoordinator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibitionCoordinator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionCoordinatorExists(exhibitionCoordinator.ID))
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
            ViewData["ClassMasterID"] = new SelectList(_context.ClassMasters, "ID", "ClassName", exhibitionCoordinator.ClassMasterID);
            return View(exhibitionCoordinator);
        }

        // GET: ExhibitionCoordinators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionCoordinator = await _context.ExhibitionCoordinators
                .Include(e => e.ClassMaster)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exhibitionCoordinator == null)
            {
                return NotFound();
            }

            return View(exhibitionCoordinator);
        }

        // POST: ExhibitionCoordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibitionCoordinator = await _context.ExhibitionCoordinators.FindAsync(id);
            _context.ExhibitionCoordinators.Remove(exhibitionCoordinator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitionCoordinatorExists(int id)
        {
            return _context.ExhibitionCoordinators.Any(e => e.ID == id);
        }
    }
}
