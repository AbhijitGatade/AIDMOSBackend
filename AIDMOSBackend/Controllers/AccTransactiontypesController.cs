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
    public class AccTransactiontypesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public AccTransactiontypesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/AccTransactiontypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccTransactiontype>>> GetAccTransactiontypes()
        {
          if (_context.AccTransactiontypes == null)
          {
              return NotFound();
          }
            return await _context.AccTransactiontypes.ToListAsync();
        }

        // GET: api/AccTransactiontypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccTransactiontype>> GetAccTransactiontype(decimal id)
        {
          if (_context.AccTransactiontypes == null)
          {
              return NotFound();
          }
            var accTransactiontype = await _context.AccTransactiontypes.FindAsync(id);

            if (accTransactiontype == null)
            {
                return NotFound();
            }

            return accTransactiontype;
        }

        // PUT: api/AccTransactiontypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccTransactiontype(decimal id, AccTransactiontype accTransactiontype)
        {
            if (id != accTransactiontype.Id)
            {
                return BadRequest();
            }

            _context.Entry(accTransactiontype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccTransactiontypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(accTransactiontype);
        }

        // POST: api/AccTransactiontypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccTransactiontype>> PostAccTransactiontype(AccTransactiontype accTransactiontype)
        {
          if (_context.AccTransactiontypes == null)
          {
              return Problem("Entity set 'ProjectDBContext.AccTransactiontypes'  is null.");
          }
            _context.AccTransactiontypes.Add(accTransactiontype);
            await _context.SaveChangesAsync();

            return Ok(accTransactiontype);
        }

        // DELETE: api/AccTransactiontypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccTransactiontype(decimal id)
        {
            if (_context.AccTransactiontypes == null)
            {
                return NotFound();
            }
            var accTransactiontype = await _context.AccTransactiontypes.FindAsync(id);
            if (accTransactiontype == null)
            {
                return NotFound();
            }

            _context.AccTransactiontypes.Remove(accTransactiontype);
            await _context.SaveChangesAsync();

            return Ok(accTransactiontype);
        }

        private bool AccTransactiontypeExists(decimal id)
        {
            return (_context.AccTransactiontypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
