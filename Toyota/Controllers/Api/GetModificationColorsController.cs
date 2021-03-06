using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toyota.Data;
using Toyota.Data.Entities;

namespace Toyota.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetModificationColorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetModificationColorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //api/GetModificationColors/42c99fea-0b33-4245-8c84-2c52c2d2ae95
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Color>>> Get(Guid id)
        {
           

         return await _context.Colors
                      .SelectMany(
                      color => color.ModificationColors,
                      (c, mc) => new { Color = c, ModColor = mc })
                      .Where(a => a.ModColor.ModificationId == id)
                      .Select(a => a.Color).ToListAsync();
        }
    }
}
