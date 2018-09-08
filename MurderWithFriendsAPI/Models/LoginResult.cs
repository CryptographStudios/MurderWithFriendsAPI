using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class LoginResult
    {
        public int LoginResultId { get; set; }
        public string Result { get; set; }
        public string Details { get; set; }

        public LoginHistory LoginHistory { get; set; }
    }
}
