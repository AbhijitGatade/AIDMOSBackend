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
    public class AccSchedulesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public AccSchedulesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/AccSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccSchedule>>> GetAccSchedules()
        {
          if (_context.AccSchedules == null)
          {
              return NotFound();
          }
            return await _context.AccSchedules.ToListAsync();
        }

        // GET: api/AccSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccSchedule>> GetAccSchedule(decimal id)
        {
          if (_context.AccSchedules == null)
          {
              return NotFound();
          }
            var accSchedule = await _context.AccSchedules.FindAsync(id);

            if (accSchedule == null)
            {
                return NotFound();
            }

            return accSchedule;
        }

        // PUT: api/AccSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccSchedule(decimal id, AccSchedule accSchedule)
        {
            if (id != accSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(accSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(accSchedule);
        }

        // POST: api/AccSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccSchedule>> PostAccSchedule(AccSchedule accSchedule)
        {
          if (_context.AccSchedules == null)
          {
              return Problem("Entity set 'ProjectDBContext.AccSchedules'  is null.");
          }
            _context.AccSchedules.Add(accSchedule);
            await _context.SaveChangesAsync();

            return Ok(accSchedule);
        }

        // DELETE: api/AccSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccSchedule(decimal id)
        {
            if (_context.AccSchedules == null)
            {
                return NotFound();
            }
            var accSchedule = await _context.AccSchedules.FindAsync(id);
            if (accSchedule == null)
            {
                return NotFound();
            }

            _context.AccSchedules.Remove(accSchedule);
            await _context.SaveChangesAsync();

            return Ok(accSchedule);
        }

        private bool AccScheduleExists(decimal id)
        {
            return (_context.AccSchedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
