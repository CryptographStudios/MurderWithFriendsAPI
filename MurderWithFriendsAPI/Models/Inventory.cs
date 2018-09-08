using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class Inventory
    {
        public long? UserId { get; set; }
        public int? ItemId { get; set; }
        public long? CharacterId { get; set; }
        public long InventoryId { get; set; }

        public Item Item { get; set; }
        public User User { get; set; }
    }
}
