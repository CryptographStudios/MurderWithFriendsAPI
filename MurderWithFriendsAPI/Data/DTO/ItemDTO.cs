using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class ItemDTO
    {
        public ItemDTO()
        {
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

        public CurrencyTypeDTO BuyCurrency { get; set; }
        public ItemTypeDTO ItemType { get; set; }
        public StatsDTO Stats { get; set; }
    }
}
