using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class Equipment
    {
        public long? CharacterId { get; set; }
        public int? ItemId { get; set; }
        public long UserId { get; set; }
        public int? Quantity { get; set; }
        public long ExperienceId { get; set; }
        public long EquipmentId { get; set; }

        public Character Character { get; set; }
        public Experience Experience { get; set; }
        public Item Item { get; set; }
        public User User { get; set; }
    }
}
