using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Data.DTO
{
    public class CharacterDTO
    {
        public CharacterDTO()
        {
            Equipment = new HashSet<EquipmentDTO>();
        }

        public long CharacterId { get; set; }
        public string Name { get; set; }
        public long BaseStatsId { get; set; }
        public long SkillSetId { get; set; }
        public long? ExperienceId { get; set; }

        public StatsDTO BaseStats { get; set; }
        public ExperienceDTO Experience { get; set; }
        public ICollection<EquipmentDTO> Equipment { get; set; }
    }
}
