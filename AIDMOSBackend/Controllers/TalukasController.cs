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
    public class TalukasController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public TalukasController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Talukas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taluka>>> GetTalukas()
        {
          if (_context.Talukas == null)
          {
              return NotFound();
          }
            return await _context.Talukas.ToListAsync();
        }

        // GET: api/Talukas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taluka>> GetTaluka(decimal id)
        {
          if (_context.Talukas == null)
          {
              return NotFound();
          }
            var taluka = await _context.Talukas.FindAsync(id);

            if (taluka == null)
            {
                return NotFound();
            }

            return taluka;
        }

        // PUT: api/Talukas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaluka(decimal id, Taluka taluka)
        {
            if (id != taluka.Id)
            {
                return BadRequest();
            }

            _context.Entry(taluka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalukaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(taluka);
        }

        // POST: api/Talukas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taluka>> PostTaluka(Taluka taluka)
        {
          if (_context.Talukas == null)
          {
              return Problem("Entity set 'ProjectDBContext.Talukas'  is null.");
          }
            _context.Talukas.Add(taluka);
            await _context.SaveChangesAsync();

            return Ok(taluka);
        }

        // DELETE: api/Talukas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaluka(decimal id)
        {
            if (_context.Talukas == null)
            {
                return NotFound();
            }
            var taluka = await _context.Talukas.FindAsync(id);
            if (taluka == null)
            {
                return NotFound();
            }

            _context.Talukas.Remove(taluka);
            await _context.SaveChangesAsync();

            return Ok(taluka);
        }

        private bool TalukaExists(decimal id)
        {
            return (_context.Talukas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
