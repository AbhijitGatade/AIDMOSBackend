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
    public class BusinessesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public BusinessesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusinesses()
        {
          if (_context.Businesses == null)
          {
              return NotFound();
          }
            return await _context.Businesses.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(decimal id)
        {
          if (_context.Businesses == null)
          {
              return NotFound();
          }
            var business = await _context.Businesses.FindAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(decimal id, Business business)
        {
            if (id != business.Id)
            {
                return BadRequest();
            }

            _context.Entry(business).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(business);
        }

        // POST: api/Businesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Business>> PostBusiness(Business business)
        {
          if (_context.Businesses == null)
          {
              return Problem("Entity set 'ProjectDBContext.Businesses'  is null.");
          }
            _context.Businesses.Add(business);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusinessExists(business.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(decimal id)
        {
            if (_context.Businesses == null)
            {
                return NotFound();
            }
            var business = await _context.Businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            _context.Businesses.Remove(business);
            await _context.SaveChangesAsync();

            return Ok(business);
        }

        private bool BusinessExists(decimal id)
        {
            return (_context.Businesses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
