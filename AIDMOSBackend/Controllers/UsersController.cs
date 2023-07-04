using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AIDMOSBackend.Context;
using AIDMOSBackend.Models;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace AIDMOSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private IConfiguration configuration;

        public UsersController(ProjectDBContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        // GET: api/Users
        [HttpGet("{businessid}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(decimal businessid)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
          if(businessid == 0)
            {
                return await _context.Users.ToListAsync();
            }
            else
            {
                return await _context.Users.Where(u => u.Businessid == businessid).ToListAsync();
            }
            
        }

        // GET: api/Users/5
        [HttpGet("{businessid}/{id}")]
        public async Task<ActionResult<User>> GetUser(decimal businessid, decimal id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(decimal id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'ProjectDBContext.Users'  is null.");
          }
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(decimal id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
     
        private bool UserExists(decimal id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("modules/{userid}")]
        public async Task<IActionResult> GetUserModules(decimal userid)
        {
            User user = new User();
            DataTable dtable = user.GetUserModules(userid, this.configuration);
            return Ok(dtable);
        }

        [HttpPost("addmodule/{userid}/{moduleid}")]
        public async Task<IActionResult> AddUserModule(decimal userid, decimal moduleid)
        {
            Usermodulemapping usermodulemapping = new Usermodulemapping();
            usermodulemapping.UserId = userid;
            usermodulemapping.ModuleId = moduleid;
            _context.Usermodulemappings.Add(usermodulemapping);
            await _context.SaveChangesAsync();
            User user = new User();
            DataTable dtable = user.GetUserModules(userid, this.configuration);
            return Ok(dtable);
        }

        [HttpDelete("removemodule/{userid}/{mappingid}")]
        public async Task<IActionResult> RemoveUserModule(decimal userid, decimal mappingid)
        {
            var mapping = await _context.Usermodulemappings.FindAsync(mappingid);
            if (mapping == null)
                return Ok();
            _context.Usermodulemappings.Remove(mapping);
            await _context.SaveChangesAsync();
            User user = new User();
            DataTable dtable = user.GetUserModules(userid, this.configuration);
            return Ok(dtable);
        }

    }
}
