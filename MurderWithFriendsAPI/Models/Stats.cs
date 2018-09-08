using System;
using System.Collections.Generic;

namespace MurderWithFriendsAPI.Models
{
    public partial class Stats
    {
        public Stats()
        {
            Character = new HashSet<Character>();
            Item = new HashSet<Item>();
        }

        public long StatsId { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Constitution { get; set; }
        public int ElectricBonus { get; set; }
        public int WaterBonus { get; set; }
        public int FireBonus { get; set; }
        public int EarthBonus { get; set; }
        public int HolyBonus { get; set; }
        public int DarkBonus { get; set; }
        public int Armor { get; set; }
        public int MagicResist { get; set; }
        public int ArmorPenetration { get; set; }
        public int MagicPenetration { get; set; }

        public ICollection<Character> Character { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
