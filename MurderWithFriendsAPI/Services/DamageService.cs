using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.Services
{
	public class DamageService
	{
        ICharacterData _characterData;
        public DamageService(ICharacterData characterData)
        {
            _characterData = characterData;
        }

        //this is probably actually a MED pattern candidate.
		public async Task<int> CalculateDamage(long attackerID, long defenderID)
		{
            var characterIds = new List<long> { attackerID, defenderID };
            var characters = await _characterData.GetCharactersDetailedInfo(characterIds);

            int attackVal = GetAttackValue(characters.Where(c => c.CharacterId == attackerID).First());
            int defenseVal = GetDefenseValue(characters.Where(c => c.CharacterId == defenderID).First());
			return attackVal - defenseVal;
		}

        //this works for a basic, physical attack only. We will have to make it more flexy
        //making public, just for the moment.
		public int GetAttackValue(Character attacker)
		{

            var equipment = attacker.Equipment.ToList();
            int attack = attacker.BaseStats.Strength;

            foreach (Equipment e in equipment)
            {
                attack += e.Item.Stats.Strength;
            }
            return attack;

        }



        private int GetDefenseValue(Character defender)
        {

            var equipment = defender.Equipment.ToList();
            int defense = defender.BaseStats.Strength;

            foreach (Equipment e in equipment)
            {
                defense += e.Item.Stats.Strength;
            }
            return defense;
        }

	}
}
