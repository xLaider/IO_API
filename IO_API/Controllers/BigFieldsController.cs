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
    public class BigFieldsController : ControllerBase
    {
        private readonly DataContext _context;

        public BigFieldsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BigFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BigField>>> GetBigFields()
        {
            return await _context.BigFields.ToListAsync();
        }

        // GET: api/BigFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BigField>> GetBigField(int id)
        {
            var bigField = await _context.BigFields.FindAsync(id);

            if (bigField == null)
            {
                return NotFound();
            }

            return bigField;
        }

        // PUT: api/BigFields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBigField(int id, BigField bigField)
        {
            if (id != bigField.ID)
            {
                return BadRequest();
            }

            _context.Entry(bigField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BigFieldExists(id))
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

        // POST: api/BigFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BigField>> PostBigField(BigField bigField)
        {
            _context.BigFields.Add(bigField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBigField", new { id = bigField.ID }, bigField);
        }

        // DELETE: api/BigFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBigField(int id)
        {
            var bigField = await _context.BigFields.FindAsync(id);
            if (bigField == null)
            {
                return NotFound();
            }

            _context.BigFields.Remove(bigField);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/GetBigFieldsListByUserID/{ID}")]
        public async Task<ActionResult<IList<BigField>>> GetBigFieldsListByUserId(string ID)
        {
            var world = await _context.Worlds.Include(x=>x.BigFields).ThenInclude(x=>x.Fields).SingleOrDefaultAsync(x=> x.UserID == ID);
            var bigFieldsList = world.BigFields;

            if (bigFieldsList == null)
            {
                return NotFound();
            }

            return Ok(bigFieldsList);
        }

        private bool BigFieldExists(int id)
        {
            return _context.BigFields.Any(e => e.ID == id);
        }
    }
}
