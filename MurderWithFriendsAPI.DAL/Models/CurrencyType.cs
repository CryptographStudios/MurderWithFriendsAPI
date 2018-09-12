using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.DAL.Models
{
    public partial class CurrencyType
    {
        public CurrencyType()
        {
            Item = new HashSet<Item>();
            UserCurrency = new HashSet<UserCurrency>();
        }

        public int CurrencyTypeId { get; set; }
        public string CurrencyTypeName { get; set; }
        public bool? Active { get; set; }
        public decimal? ValueInUsd { get; set; }

        public ICollection<Item> Item { get; set; }
        public ICollection<UserCurrency> UserCurrency { get; set; }
    }
}
