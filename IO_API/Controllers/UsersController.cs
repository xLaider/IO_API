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
using Microsoft.AspNetCore.Authorization;
using IO_API.Auth;

namespace IO_API.Controllers
{
   //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context; //Depedency Injection

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
         
            return user;
        }
        // GET: api/Users/5
        [HttpGet("/email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Users/5
        [HttpGet("/nickname/{nickname}")]
        public async Task<ActionResult<User>> GetUserByNickname(string nickname)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Nickname == nickname);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        // GET: api/Users/6
        [HttpGet("/GetUserByEmailAndPassword/{email}/{password}")]
        public async Task<ActionResult<User>> GetUserByEmailAndPassword(string email,string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            
            if(user.Password!=password)
            {
                return NotFound();
            }
            return user;
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
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

        [HttpGet("/RankingScore/ByScore")]
        public async Task<ActionResult<List<User>>> RankingScore()
        {

            var listrank = await _context.Users.OrderBy(x=>x.Score).Take(5).ToListAsync();
            
            return listrank;
            
        }

        //GET: api/Users/7
        [HttpGet("/RankingCoins/ByCoins")]

        public async Task<ActionResult<List<User>>> RankingCoins()
        {
            var listrank = await _context.Users.OrderBy(x=>x.Coins).Take(5).ToListAsync();
            
            return listrank;

        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
}
