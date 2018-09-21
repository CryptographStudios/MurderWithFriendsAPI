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
    //Pretty sure we won't update stats independently of the thing that the stats relate to.
    //So we might rip this guy out entirely.
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
		private DamageService _damageService;
        ICharacterData _characterData;

		public StatsController( ICharacterData characterData, DamageService damageService)
        {
            _characterData = characterData;
			_damageService = damageService;
		}

        //Still still don't understand this.
        // GET: api/Stats
        //[HttpGet]
        //public IEnumerable<Stats> GetStats()
        //{
        //    return _characterData.Stats;
        //}

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStats([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<long> ids = new List<long> { id };

            var character = await _characterData.GetCharactersDetailedInfo(ids);
            Stats stats = character.FirstOrDefault().BaseStats;

            if (stats == null)
            {
                return NotFound();
            }

            return Ok(stats);
        }


        // PUT: api/Stats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStats([FromRoute] long id, [FromBody] Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != character.BaseStatsId)
            {
                return BadRequest();
            }

            var characters = new List<Character> { character };
            await _characterData.AddOrUpdateCharacters(characters);
            

            return NoContent();
        }

        //this is dumb. I don't like.
        // POST: api/Stats
        [HttpPost]
        public async Task<IActionResult> PostStats([FromBody] Character character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var characters = new List<Character> { character };
            await _characterData.AddOrUpdateCharacters(characters);


            return NoContent();
        }

        //No fucking way this is going to work. we will orphan shit.
        // DELETE: api/Stats/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStats([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var stats = await _characterData.Stats.FindAsync(id);
        //    if (stats == null)
        //    {
        //        return NotFound();
        //    }

        //    _characterData.Stats.Remove(stats);
        //    await _characterData.SaveChangesAsync();

        //    return Ok(stats);
        //}

        //this method is not needed or used.
        //private bool StatsExists(long id)
        //{
        //    return _characterData.Stats.Any(e => e.StatsId == id);
        //}
    }
}