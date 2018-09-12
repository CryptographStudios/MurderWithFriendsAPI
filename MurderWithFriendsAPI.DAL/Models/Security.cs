using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.DAL.Models
{
    public partial class Security
    {
        public long SecurityId { get; set; }
        public long UserId { get; set; }
        public string SaltedHash { get; set; }

        public User User { get; set; }
    }
}
