using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class User
    {
        public User()
        {
            Equipment = new HashSet<Equipment>();
            Inventory = new HashSet<Inventory>();
            LoginHistory = new HashSet<LoginHistory>();
            Security = new HashSet<Security>();
            UserCurrency = new HashSet<UserCurrency>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Active { get; set; }

        public ICollection<Equipment> Equipment { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<LoginHistory> LoginHistory { get; set; }
        public ICollection<Security> Security { get; set; }
        public ICollection<UserCurrency> UserCurrency { get; set; }
    }
}
