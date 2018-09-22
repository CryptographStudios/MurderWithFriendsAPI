using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using MurderWithFriendsAPI.DAL.DataAccess.Implementations;
using MurderWithFriendsAPI.DAL.Models;

namespace MurderWithFriendsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        IItemData _itemData;

        ItemController()
        {
            _itemData = new ItemData();
        }
        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var items = await _itemData.GetAllItemsAsync();

            return Ok(items);
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(long id)
        {
            var items = await _itemData.GetItemAsync(id);

            return Ok(items);
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Item item)
        {
            await _itemData.AddOrUpdateItemAsync(item);

            return Ok(item.ItemId);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Item item)
        {
            await _itemData.AddOrUpdateItemAsync(item);

            return Ok(item.ItemId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
