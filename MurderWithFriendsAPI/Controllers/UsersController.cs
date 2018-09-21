using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using MurderWithFriendsAPI.DAL.Models;
using MurderWithFriendsAPI.Services;

namespace MurderWithFriendsAPI.Controllers
{

	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserData _userData;
	
		public UsersController(IUserData userData, AuthService authService)
		{
			_userData = userData;			
		}

        //I Still think this is a bad idea.
		// GET: api/Users
		//[HttpGet]	
		//public IEnumerable<User> GetUser()
  //      {
  //          return _context.User;
  //      }

        // GET: api/Users/5
        [HttpGet("{id}")]		
		public async Task<IActionResult> GetUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userData.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] long id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            await _userData.AddOrUpdateUser(user);

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userData.AddOrUpdateUser(user);
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userData.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userData.DeleteUser(id);
            
            return Ok(user);
        }

        private async Task<bool> UserExists(long id)
        {
            return await UserExists(id);
        }
    }
}