using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Toyota.Data;
using Toyota.Data.Entities;

namespace Toyota.Controllers.Standart
{
    public class StandartModificationColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StandartModificationColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StandartModificationColors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ModificationColors.Include(m => m.Color).Include(m => m.Modification);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StandartModificationColors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modificationColors = await _context.ModificationColors
                .Include(m => m.Color)
                .Include(m => m.Modification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modificationColors == null)
            {
                return NotFound();
            }

            return View(modificationColors);
        }

        // GET: StandartModificationColors/Create
        public IActionResult Create()
        {

            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["ModificationId"] = new SelectList(_context.Modifications, "Id", "Name");
            return View();
        }

        // POST: StandartModificationColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Slug,ModificationId,ColorId,ImgUrl")] ModificationColors modificationColors, IFormFile fileToStorage)
        {
            if (ModelState.IsValid)
            {
                modificationColors.Id = Guid.NewGuid();

                modificationColors.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "modification_colors_thumbs");
                _context.Add(modificationColors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", modificationColors.ColorId);
            ViewData["ModificationId"] = new SelectList(_context.Modifications, "Id", "Name", modificationColors.ModificationId);
            return View(modificationColors);
        }

        // GET: StandartModificationColors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modificationColors = await _context.ModificationColors.FindAsync(id);
            if (modificationColors == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", modificationColors.ColorId);
            ViewData["ModificationId"] = new SelectList(_context.Modifications, "Id", "Name", modificationColors.ModificationId);
            return View(modificationColors);
        }

        // POST: StandartModificationColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Slug,ModificationId,ColorId,ImgUrl")] ModificationColors modificationColors, IFormFile fileToStorage)
        {
            if (id != modificationColors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    modificationColors.ImgUrl = await Helpers.Media.UploadImage(fileToStorage, "modification_colors_thumbs");
                    _context.Update(modificationColors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModificationColorsExists(modificationColors.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Name", modificationColors.ColorId);
            ViewData["ModificationId"] = new SelectList(_context.Modifications, "Id", "Name", modificationColors.ModificationId);
            return View(modificationColors);
        }

        // GET: StandartModificationColors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modificationColors = await _context.ModificationColors
                .Include(m => m.Color)
                .Include(m => m.Modification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modificationColors == null)
            {
                return NotFound();
            }

            return View(modificationColors);
        }

        // POST: StandartModificationColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modificationColors = await _context.ModificationColors.FindAsync(id);
            _context.ModificationColors.Remove(modificationColors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModificationColorsExists(Guid id)
        {
            return _context.ModificationColors.Any(e => e.Id == id);
        }
    }
}
