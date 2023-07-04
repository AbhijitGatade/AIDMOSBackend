using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AIDMOSBackend.Context;
using AIDMOSBackend.Models;

namespace AIDMOSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulemenusController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public ModulemenusController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Modulemenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulemenu>>> GetModulemenus()
        {
          if (_context.Modulemenus == null)
          {
              return NotFound();
          }
            return await _context.Modulemenus.ToListAsync();
        }

        // GET: api/Modulemenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modulemenu>> GetModulemenu(decimal id)
        {
          if (_context.Modulemenus == null)
          {
              return NotFound();
          }
            var modulemenu = await _context.Modulemenus.FindAsync(id);

            if (modulemenu == null)
            {
                return NotFound();
            }

            return modulemenu;
        }

        // PUT: api/Modulemenus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulemenu(decimal id, Modulemenu modulemenu)
        {
            if (id != modulemenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(modulemenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModulemenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(modulemenu);
        }

        // POST: api/Modulemenus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modulemenu>> PostModulemenu(Modulemenu modulemenu)
        {
          if (_context.Modulemenus == null)
          {
              return Problem("Entity set 'ProjectDBContext.Modulemenus'  is null.");
          }
            _context.Modulemenus.Add(modulemenu);
            await _context.SaveChangesAsync();

            return Ok(modulemenu);
        }

        // DELETE: api/Modulemenus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModulemenu(decimal id)
        {
            if (_context.Modulemenus == null)
            {
                return NotFound();
            }
            var modulemenu = await _context.Modulemenus.FindAsync(id);
            if (modulemenu == null)
            {
                return NotFound();
            }

            _context.Modulemenus.Remove(modulemenu);
            await _context.SaveChangesAsync();

            return Ok(modulemenu);
        }

        private bool ModulemenuExists(decimal id)
        {
            return (_context.Modulemenus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
