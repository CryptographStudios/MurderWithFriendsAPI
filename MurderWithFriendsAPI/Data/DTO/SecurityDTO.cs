using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class SecurityDTO
    {
        public long SecurityId { get; set; }
        public long UserId { get; set; }
        public string SaltedHash { get; set; }
    }
}
