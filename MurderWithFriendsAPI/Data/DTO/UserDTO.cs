using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class UserDTO
    {
        public UserDTO()
        {
            Equipment = new HashSet<EquipmentDTO>();
            Inventory = new HashSet<ItemDTO>();
            LoginHistory = new HashSet<LoginHistoryDTO>();
            Security = new HashSet<SecurityDTO>();
            UserCurrency = new HashSet<UserCurrencyDTO>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Active { get; set; }

        public ICollection<EquipmentDTO> Equipment { get; set; }
        public ICollection<ItemDTO> Inventory { get; set; }
        public ICollection<LoginHistoryDTO> LoginHistory { get; set; }
        public ICollection<SecurityDTO> Security { get; set; }
        public ICollection<UserCurrencyDTO> UserCurrency { get; set; }
    }
}
