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
    public class DistrictsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public DistrictsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
          if (_context.Districts == null)
          {
              return NotFound();
          }
            return await _context.Districts.ToListAsync();
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<District>> GetDistrict(decimal id)
        {
          if (_context.Districts == null)
          {
              return NotFound();
          }
            var district = await _context.Districts.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
        }

        // PUT: api/Districts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrict(decimal id, District district)
        {
            if (id != district.Id)
            {
                return BadRequest();
            }

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(district);
        }

        // POST: api/Districts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
          if (_context.Districts == null)
          {
              return Problem("Entity set 'ProjectDBContext.Districts'  is null.");
          }
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();

            return Ok(district);
        }

        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(decimal id)
        {
            if (_context.Districts == null)
            {
                return NotFound();
            }
            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();

            return Ok(district);
        }

        private bool DistrictExists(decimal id)
        {
            return (_context.Districts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
