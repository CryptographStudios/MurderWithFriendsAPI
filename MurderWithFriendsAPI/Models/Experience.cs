using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class Experience
    {
        public Experience()
        {
            Character = new HashSet<Character>();
            Equipment = new HashSet<Equipment>();
        }

        public long ExperienceId { get; set; }
        public long Amount { get; set; }
        public int CurrentLevel { get; set; }

        public ICollection<Character> Character { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}
