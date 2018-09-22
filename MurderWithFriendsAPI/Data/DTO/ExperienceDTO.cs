using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public partial class ExperienceDTO
    {
        public ExperienceDTO()
        {
        }

        public long ExperienceId { get; set; }
        public long Amount { get; set; }
        public int CurrentLevel { get; set; }

    }
}
