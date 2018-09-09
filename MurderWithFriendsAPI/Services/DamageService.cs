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

		private int GetAttackValue(long characterID)
		{
			int attackVal = 0;
			using (var context = new ItsOnlyHeroesContext())
			{
				List<Character> achar = context.Character.Where(x => x.CharacterId == characterID)
					.Include(x => x.BaseStats).ToList();								
				
				foreach (var stat in achar.Where(x => x.BaseStats != null))
				{
					attackVal += 
						stat.BaseStats.Agility +
						stat.BaseStats.Armor +
						stat.BaseStats.ArmorPenetration +
						stat.BaseStats.Charisma +
						stat.BaseStats.Constitution +
						stat.BaseStats.DarkBonus +
						stat.BaseStats.Dexterity +
						stat.BaseStats.EarthBonus +
						stat.BaseStats.ElectricBonus +
						stat.BaseStats.FireBonus +
						stat.BaseStats.HolyBonus +
						stat.BaseStats.Intelligence +
						stat.BaseStats.MagicPenetration +
						stat.BaseStats.MagicResist +
						stat.BaseStats.Strength +
						stat.BaseStats.WaterBonus +
						stat.BaseStats.Wisdom;						
				}
			}

			return attackVal;
		}


		private int GetDefenseValue(long characterID)
		{
			int defenseVal = 0;
			using (var context = new ItsOnlyHeroesContext())
			{
				List<Character> achar = context.Character.Where(x => x.CharacterId == characterID)
					.Include(x => x.BaseStats).ToList();

				foreach (var stat in achar.Where(x => x.BaseStats != null))
				{
					defenseVal +=
						stat.BaseStats.Agility +
						stat.BaseStats.Armor +
						stat.BaseStats.ArmorPenetration +
						stat.BaseStats.Charisma +
						stat.BaseStats.Constitution +
						stat.BaseStats.DarkBonus +
						stat.BaseStats.Dexterity +
						stat.BaseStats.EarthBonus +
						stat.BaseStats.ElectricBonus +
						stat.BaseStats.FireBonus +
						stat.BaseStats.HolyBonus +
						stat.BaseStats.Intelligence +
						stat.BaseStats.MagicPenetration +
						stat.BaseStats.MagicResist +
						stat.BaseStats.Strength +
						stat.BaseStats.WaterBonus +
						stat.BaseStats.Wisdom;
				}
			}

			return defenseVal;
		}

	}
}
