using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class CurrencyTypeDTO
    {
        public CurrencyTypeDTO()
        {
        }

        public int CurrencyTypeId { get; set; }
        public string CurrencyTypeName { get; set; }
        public bool? Active { get; set; }
        public decimal? ValueInUsd { get; set; }
    }
}
