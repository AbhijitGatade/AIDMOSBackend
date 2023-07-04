using AIDMOSBackend.Context;
using AIDMOSBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AIDMOSBackend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public AuthenticationController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AccGroup>> PostLogin(Login login)
        {
            return Ok(_context.Users.Where(u => u.Username == login.username && u.Password == login.password).ToList());
        }

    }
}
