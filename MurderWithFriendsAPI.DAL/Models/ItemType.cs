using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.DAL.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            Item = new HashSet<Item>();
        }

        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeDescription { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
