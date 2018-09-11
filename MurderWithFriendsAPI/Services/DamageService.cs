using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.Services
{
	public class DamageService
	{
		public int CalculateDamage(long attackerID, long defenderID)
		{			
			int attackVal = GetAttackValue(attackerID);
			int defenseVal = 1;
			return attackVal - defenseVal;
		}

        //this works for a basic, physical attack only. We will have to make it more flexy
        //making public, just for the moment.
		public int GetAttackValue(long characterID)
		{
			using (var context = new ItsOnlyHeroesContext())
			{
                Character character = context.Character.Where(x => x.CharacterId == characterID)
                                                            .Include(x => x.BaseStats)
                                                            .Include(x => x.Equipment)                                                            
                                                            .FirstOrDefault();								
				
                var equipment = character.Equipment.ToList();
                int attack = character.BaseStats.Strength;

                foreach (Equipment e in equipment)
                {
                    //this is stupid. let's not do it this way.
                    Item item = context.Item.Where(x => x.ItemId == e.ItemId)
                        .Include(x => x.Stats)
                        .FirstOrDefault() ;

                    attack += item.Stats.Strength;
                }
                return attack;
			}	
		}



		private int GetDefenseValue(long characterID)
		{
            int defenseVal = 0;
            using (var context = new ItsOnlyHeroesContext())
            {
                //This really needs to go in a DAL.
                Character character = context.Character.Where(x => x.CharacterId == characterID)
                                                            .Include(x => x.BaseStats)
                                                            .Include(x => x.Equipment)
                                                            .FirstOrDefault();

                var equipment = character.Equipment.ToList();
                int attack = character.BaseStats.Armor;

                foreach (Equipment e in equipment)
                {
                    attack += e.Item.Stats.Armor;
                }
            }

            return defenseVal;
		}

	}
}
