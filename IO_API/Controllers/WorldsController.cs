﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IO_API.Data;
using IO_API.Models;
using IO_API.IRepositories;

namespace IO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWorldRepository _worldRepository;

        public WorldsController(DataContext context,
            IWorldRepository worldRepository)
        {
            _worldRepository = worldRepository;
            _context = context;
        }

        // GET: api/Worlds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<World>>> GetWorlds()
        {
            return await _context.Worlds.ToListAsync();
        }

        // GET: api/Worlds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<World>> GetWorld(int id)
        {
            var world = await _context.Worlds.FindAsync(id);

            if (world == null)
            {
                return NotFound();
            }

            return world;
        }

        // PUT: api/Worlds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorld(int id, World world)
        {
            if (id != world.ID)
            {
                return BadRequest();
            }

            _context.Entry(world).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldExists(id))
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

        // POST: api/Worlds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<World>> PostWorld(World world)
        {
            _context.Worlds.Add(world);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorld", new { id = world.ID }, world);
        }

        // DELETE: api/Worlds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorld(int id)
        {
            var world = await _context.Worlds.FindAsync(id);
            if (world == null)
            {
                return NotFound();
            }

            _context.Worlds.Remove(world);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/GetUserEarningsByUserID/{id}")]
        public async Task<ActionResult<int>> GetUserEarningsByUserID(string id)
        {
            var world = await _context.Worlds.Include(x=>x.BigFields).ThenInclude(x=>x.Fields).ThenInclude(x=>x.PlacedBuilding).
                SingleOrDefaultAsync(x=>x.UserID == id);

            if (world == null)
            {
                return NotFound();
            }

            int earnings = _worldRepository.CalculateEarningsFromWorld(world);

            return Ok(earnings);
        }

        private bool WorldExists(int id)
        {
            return _context.Worlds.Any(e => e.ID == id);
        }
    }
}
