using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class LoginHistory
    {
        public long LoginHistoryId { get; set; }
        public long? UserId { get; set; }
        public string Ipaddress { get; set; }
        public int LoginResultId { get; set; }

        public LoginResult LoginResult { get; set; }
        public User User { get; set; }
    }
}
