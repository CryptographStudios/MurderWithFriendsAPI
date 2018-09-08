using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class UserCurrency
    {
        public long UserId { get; set; }
        public int CurrencyId { get; set; }
        public int Amount { get; set; }
        public long UserCurrencyId { get; set; }

        public CurrencyType Currency { get; set; }
        public User User { get; set; }
    }
}
