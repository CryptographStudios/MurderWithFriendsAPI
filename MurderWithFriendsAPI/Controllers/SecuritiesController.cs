using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.Models;

namespace MurderWithFriendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritiesController : ControllerBase
    {
        private readonly ItsOnlyHeroesContext _context;

        public SecuritiesController(ItsOnlyHeroesContext context)
        {
            _context = context;
        }

        // GET: api/Securities
        [HttpGet]
        public IEnumerable<Security> GetSecurity()
        {
            return _context.Security;
        }

        // GET: api/Securities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecurity([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var security = await _context.Security.FindAsync(id);

            if (security == null)
            {
                return NotFound();
            }

            return Ok(security);
        }

        // PUT: api/Securities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecurity([FromRoute] long id, [FromBody] Security security)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != security.SecurityId)
            {
                return BadRequest();
            }

            _context.Entry(security).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecurityExists(id))
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

        // POST: api/Securities
        [HttpPost]
        public async Task<IActionResult> PostSecurity([FromBody] Security security)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Security.Add(security);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecurity", new { id = security.SecurityId }, security);
        }

        // DELETE: api/Securities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecurity([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var security = await _context.Security.FindAsync(id);
            if (security == null)
            {
                return NotFound();
            }

            _context.Security.Remove(security);
            await _context.SaveChangesAsync();

            return Ok(security);
        }

        private bool SecurityExists(long id)
        {
            return _context.Security.Any(e => e.SecurityId == id);
        }
    }
}