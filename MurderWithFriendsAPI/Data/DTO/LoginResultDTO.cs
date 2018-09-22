using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class LoginResultDTO
    {
        public int LoginResultId { get; set; }
        public string Result { get; set; }
        public string Details { get; set; }
    }
}
