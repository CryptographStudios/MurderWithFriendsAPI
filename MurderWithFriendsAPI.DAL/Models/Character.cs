using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.DAL.Models
{
    public partial class Character
    {
        public Character()
        {
            Equipment = new HashSet<Equipment>();
        }

        public long CharacterId { get; set; }
        public string Name { get; set; }
        public long BaseStatsId { get; set; }
        public long SkillSetId { get; set; }
        public long? ExperienceId { get; set; }

        public Stats BaseStats { get; set; }
        public Experience Experience { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}
