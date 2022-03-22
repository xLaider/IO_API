#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IO_API.Data;
using IO_API.Models;

namespace IO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersProgressInfoesController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersProgressInfoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UsersProgressInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersProgressInfo>>> GetUsersProgressInfo()
        {
            return await _context.UsersProgressInfo.ToListAsync();
        }

        // GET: api/UsersProgressInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersProgressInfo>> GetUsersProgressInfo(string id)
        {
            var usersProgressInfo = await _context.UsersProgressInfo.FindAsync(id);

            if (usersProgressInfo == null)
            {
                return NotFound();
            }

            return usersProgressInfo;
        }

        [HttpGet("/GetUsersProgressInfoByUserID/{id}")]
        public async Task<ActionResult<UsersProgressInfo>> GetUsersProgressInfoByUserID(string id)
        {
            var usersProgressInfo = await _context.UsersProgressInfo.SingleOrDefaultAsync(x => x.UserID == id);

            if (usersProgressInfo == null)
            {
                return NotFound();
            }

            return usersProgressInfo;
        }

        // PUT: api/UsersProgressInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersProgressInfo(string id, UsersProgressInfo usersProgressInfo)
        {
            if (id != usersProgressInfo.UserID)
            {
                return BadRequest();
            }

            _context.Entry(usersProgressInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersProgressInfoExists(id))
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

        // POST: api/UsersProgressInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersProgressInfo>> PostUsersProgressInfo(UsersProgressInfo usersProgressInfo)
        {
            _context.UsersProgressInfo.Add(usersProgressInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersProgressInfoExists(usersProgressInfo.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsersProgressInfo", new { id = usersProgressInfo.UserID }, usersProgressInfo);
        }

        // DELETE: api/UsersProgressInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersProgressInfo(string id)
        {
            var usersProgressInfo = await _context.UsersProgressInfo.FindAsync(id);
            if (usersProgressInfo == null)
            {
                return NotFound();
            }

            _context.UsersProgressInfo.Remove(usersProgressInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersProgressInfoExists(string id)
        {
            return _context.UsersProgressInfo.Any(e => e.UserID == id);
        }
    }
}
