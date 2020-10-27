using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public AppUsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUser()
        {
            return await _context.AppUser.ToListAsync();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int id)
        {
            var appUser = await _context.AppUser.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        // POST: api/AppUsers
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            _context.AppUser.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUser>> DeleteAppUser(int id)
        {
            var appUser = await _context.AppUser.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUser.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUser.Any(e => e.Id == id);
        }
    }
}
