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
    public class FinancialyearsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public FinancialyearsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Financialyears
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Financialyear>>> GetFinancialyears()
        {
          if (_context.Financialyears == null)
          {
              return NotFound();
          }
            return await _context.Financialyears.ToListAsync();
        }

        // GET: api/Financialyears/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Financialyear>> GetFinancialyear(decimal id)
        {
          if (_context.Financialyears == null)
          {
              return NotFound();
          }
            var financialyear = await _context.Financialyears.FindAsync(id);

            if (financialyear == null)
            {
                return NotFound();
            }

            return financialyear;
        }

        // PUT: api/Financialyears/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialyear(decimal id, Financialyear financialyear)
        {
            if (id != financialyear.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialyear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialyearExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Financialyears
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Financialyear>> PostFinancialyear(Financialyear financialyear)
        {
          if (_context.Financialyears == null)
          {
              return Problem("Entity set 'ProjectDBContext.Financialyears'  is null.");
          }
            _context.Financialyears.Add(financialyear);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FinancialyearExists(financialyear.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFinancialyear", new { id = financialyear.Id }, financialyear);
        }

        // DELETE: api/Financialyears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialyear(decimal id)
        {
            if (_context.Financialyears == null)
            {
                return NotFound();
            }
            var financialyear = await _context.Financialyears.FindAsync(id);
            if (financialyear == null)
            {
                return NotFound();
            }

            _context.Financialyears.Remove(financialyear);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialyearExists(decimal id)
        {
            return (_context.Financialyears?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
