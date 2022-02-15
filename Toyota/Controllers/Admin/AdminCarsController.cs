using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toyota.Data;

namespace Toyota.Controllers.Admin
{
    public class AdminCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminCarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Models.ToListAsync());
        }

        public async Task<IActionResult> ModelModifications(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.OpenModel = _context.Models.First(model => model.Id == id);

            return View(await _context.Modifications.Include(modification => modification.ModificationColors)
                    .Where(mod => mod.ModelId == id).ToListAsync());
        }
    }
}
