using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class ItemTypeDTO
    {
        public ItemTypeDTO()
        {
        }

        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeDescription { get; set; }
    }
}
