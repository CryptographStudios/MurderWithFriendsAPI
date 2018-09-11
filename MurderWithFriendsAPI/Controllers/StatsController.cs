﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.Models;
using MurderWithFriendsAPI.Services;

namespace MurderWithFriendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly ItsOnlyHeroesContext _context;
		private DamageService _damageService;

		public StatsController(ItsOnlyHeroesContext context, DamageService damageService)
        {
            _context = context;
			_damageService = damageService;
		}

        // GET: api/Stats
        [HttpGet]
        public IEnumerable<Stats> GetStats()
        {
            return _context.Stats;
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStats([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stats = await _context.Stats.FindAsync(id); 

            if (stats == null)
            {
                return NotFound();
            }

            return Ok(stats);
        }

        // PUT: api/Stats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStats([FromRoute] long id, [FromBody] Stats stats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stats.StatsId)
            {
                return BadRequest();
            }

            _context.Entry(stats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatsExists(id))
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

        // POST: api/Stats
        [HttpPost]
        public async Task<IActionResult> PostStats([FromBody] Stats stats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stats.Add(stats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStats", new { id = stats.StatsId }, stats);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStats([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stats = await _context.Stats.FindAsync(id);
            if (stats == null)
            {
                return NotFound();
            }

            _context.Stats.Remove(stats);
            await _context.SaveChangesAsync();

            return Ok(stats);
        }

        private bool StatsExists(long id)
        {
            return _context.Stats.Any(e => e.StatsId == id);
        }
    }
}