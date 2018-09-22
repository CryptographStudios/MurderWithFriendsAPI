using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class UserCurrencyDTO
    {
        public int CurrencyId { get; set; }
        public int Amount { get; set; }
        public CurrencyTypeDTO Currency { get; set; }
    }
}
