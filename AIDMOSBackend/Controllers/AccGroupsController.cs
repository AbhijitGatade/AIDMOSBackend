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
    public class AccGroupsController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public AccGroupsController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/AccGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccGroup>>> GetAccGroups()
        {
          if (_context.AccGroups == null)
          {
              return NotFound();
          }
            return await _context.AccGroups.ToListAsync();
        }

        // GET: api/AccGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccGroup>> GetAccGroup(decimal id)
        {
          if (_context.AccGroups == null)
          {
              return NotFound();
          }
            var accGroup = await _context.AccGroups.FindAsync(id);

            if (accGroup == null)
            {
                return NotFound();
            }

            return accGroup;
        }

        // PUT: api/AccGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccGroup(decimal id, AccGroup accGroup)
        {
            if (id != accGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(accGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(accGroup);
        }

        // POST: api/AccGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccGroup>> PostAccGroup(AccGroup accGroup)
        {
          if (_context.AccGroups == null)
          {
              return Problem("Entity set 'ProjectDBContext.AccGroups'  is null.");
          }
            _context.AccGroups.Add(accGroup);
            await _context.SaveChangesAsync();

            return Ok(accGroup);
        }

        // DELETE: api/AccGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccGroup(decimal id)
        {
            if (_context.AccGroups == null)
            {
                return NotFound();
            }
            var accGroup = await _context.AccGroups.FindAsync(id);
            if (accGroup == null)
            {
                return NotFound();
            }

            _context.AccGroups.Remove(accGroup);
            await _context.SaveChangesAsync();

            return Ok(accGroup);
        }

        private bool AccGroupExists(decimal id)
        {
            return (_context.AccGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
