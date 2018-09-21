using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.DAL.Models;
using MurderWithFriendsAPI.DAL.DataAccess;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;

namespace MurderWithFriendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuritiesController : ControllerBase
    {
        private readonly ISecurityData _securityData;

        public SecuritiesController(ISecurityData securityData)
        {
            _securityData = securityData;
        }

        //WTF is this for?
        // GET: api/Securities
        //[HttpGet]
        //public IEnumerable<Security> GetSecurity()
        //{
        //    return _securityData.Security;
        //}

        // GET: api/Securities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecurity([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var security = await _securityData.GetSecurity(id);

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

            try
            {
                await _securityData.AddSecurity(security);
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

            await _securityData.AddSecurity(security);
            
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

            var security = await _securityData.GetSecurity(id);
            if (security == null)
            {
                return NotFound();
            }

            await _securityData.DeleteSecurity(id);

            return Ok(security);
        }

        private bool SecurityExists(long id)
        {
            var sec =  _securityData.GetSecurity(id);
            bool exists = false;

            if (sec != null)
                exists = true;

            return exists;
        }
    }
}