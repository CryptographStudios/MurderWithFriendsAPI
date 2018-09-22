using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class LoginHistoryDTO
    {
        public long LoginHistoryId { get; set; }
        public long? UserId { get; set; }
        public string Ipaddress { get; set; }
        public int LoginResultId { get; set; }

        public LoginResultDTO LoginResult { get; set; }
    }
}
