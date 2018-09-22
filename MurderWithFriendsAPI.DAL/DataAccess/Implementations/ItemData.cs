using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.DAL.DataAccess.Implementations
{
    class ItemData : IItemData
    {
        public Task AddOrUpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            using (var context = new ItsOnlyHeroesContext())
            {
                var items = await context.Item.Where(x => x.Active == true)
                    .Include(x => x.ItemType)
                    .Include(x => x.Stats)
                    .Include(x => x.BuyCurrency)
                    .ToListAsync();

                return items;
            }
        }

        public async Task<IEnumerable<ItemType>> GetAllItemTypesAsync()
        {
            using (var context = new ItsOnlyHeroesContext())
            {
                var itemTypes = await context.ItemType.ToListAsync();
                return itemTypes;
            }
        }

        public async Task<Item> GetItemAsync(long itemId)
        {
            using (var context = new ItsOnlyHeroesContext())
            {
                var items = await context.Item.Where(x => x.Active == true)
                    .Where(x => x.ItemId == itemId)
                    .Include(x => x.ItemType)
                    .Include(x => x.Stats)
                    .Include(x => x.BuyCurrency)
                    .FirstOrDefaultAsync();

                return items;
            }
        }
    }
}
