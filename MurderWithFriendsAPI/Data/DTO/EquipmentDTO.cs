using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class EquipmentDTO
    {
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public long ExperienceId { get; set; }
        public long EquipmentId { get; set; }

        public ExperienceDTO Experience { get; set; }
        public ItemDTO Item { get; set; }
    }
}
