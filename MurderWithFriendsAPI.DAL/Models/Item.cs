using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.DAL.Models
{
    public partial class Item
    {
        public Item()
        {
            Equipment = new HashSet<Equipment>();
            Inventory = new HashSet<Inventory>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SellValue { get; set; }
        public int? BuyValue { get; set; }
        public int? BuyCurrencyId { get; set; }
        public int ItemTypeId { get; set; }
        public bool Active { get; set; }
        public long? StatsId { get; set; }

        public CurrencyType BuyCurrency { get; set; }
        public ItemType ItemType { get; set; }
        public Stats Stats { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
