using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.DAL.DataAccess.Interfaces
{
    public interface IItemData
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();

        Task<IEnumerable<ItemType>> GetAllItemTypesAsync();

        Task AddOrUpdateItemAsync(Item item);

        Task<Item> GetItemAsync(long itemId);
    }
}
