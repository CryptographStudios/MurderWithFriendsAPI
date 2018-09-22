using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MurderWithFriendsAPI.Services;

namespace MurderWithFriendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageController : ControllerBase
    {

		private DamageService _damageService;

		public DamageController(DamageService damageService)
		{
			_damageService = damageService;
		}

		// GET: api/Damage
		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

   //     // GET: api/Damage/5
   //     [HttpGet("{attackerid}/{defenderid}", Name = "Get")]
   //     public async Task<int> Get(long attackerId, long defenderId)
   //     {
			//return await _damageService.CalculateDamage(attackerId, defenderId);
   //     }

        // POST: api/Damage
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Damage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
