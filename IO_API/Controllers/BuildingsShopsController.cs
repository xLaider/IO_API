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
    public class BuildingsShopsController : ControllerBase
    {
        private readonly DataContext _context;

        public BuildingsShopsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BuildingsShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingsShop>>> GetBuildingsShop()
        {
            return await _context.BuildingsShop.ToListAsync();
        }

        // GET: api/BuildingsShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingsShop>> GetBuildingsShop(int id)
        {
            var buildingsShop = await _context.BuildingsShop.FindAsync(id);

            if (buildingsShop == null)
            {
                return NotFound();
            }

            return buildingsShop;
        }

        // PUT: api/BuildingsShops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildingsShop(int id, BuildingsShop buildingsShop)
        {
            if (id != buildingsShop.ID)
            {
                return BadRequest();
            }

            _context.Entry(buildingsShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingsShopExists(id))
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

        // POST: api/BuildingsShops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BuildingsShop>> PostBuildingsShop(BuildingsShop buildingsShop)
        {
            _context.BuildingsShop.Add(buildingsShop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildingsShop", new { id = buildingsShop.ID }, buildingsShop);
        }

        // DELETE: api/BuildingsShops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuildingsShop(int id)
        {
            var buildingsShop = await _context.BuildingsShop.FindAsync(id);
            if (buildingsShop == null)
            {
                return NotFound();
            }

            _context.BuildingsShop.Remove(buildingsShop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BuildingsShopExists(int id)
        {
            return _context.BuildingsShop.Any(e => e.ID == id);
        }
    }
}
