using MurderWithFriendsAPI.DAL.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MurderWithFriendsAPI.DAL.DataAccess.Implementations
{
    //these should all be async later. I'm being lazy.
    public class CharacterData : ICharacterData
    {
        private readonly ItsOnlyHeroesContext _dbContext;

        public CharacterData()
        {
            _dbContext = new ItsOnlyHeroesContext();
        }

        public async Task<IEnumerable<Character>> GetCharactersBasicInfo(List<long> characterIds)
        {
            var characters = await _dbContext.Character
                                        .Where(c => characterIds.Contains(c.CharacterId))
                                        .ToListAsync();

            return characters;
        }

        public async Task<IEnumerable<Character>> GetCharactersDetailedInfo(List<long> characterIds)
        {
            var characters = await _dbContext.Character
                                        .Where(c => characterIds.Contains(c.CharacterId))
                                        .Include( c => c.Experience)
                                        .Include( c=> c.Equipment.Select( e => e.Item))
                                        .ToListAsync();

            return characters;
        }

        public async Task AddOrUpdateCharacters(IEnumerable<Character> characters)
        {
            var newCharacters = characters.Where(c => c.CharacterId == 0).ToList();
            var updatedCharacters = characters.Where(c => c.CharacterId == 0).ToList();

            await AddCharacters(newCharacters);
            
        }

        private async Task AddCharacters(IEnumerable<Character> characters)
        {
            _dbContext.Character.AddRange(characters);
            await _dbContext.SaveChangesAsync();
        }

        private async Task UpdateCharacters(IEnumerable<Character> characters)
        {
            var characterIds = characters.Select(c => c.CharacterId).ToList();
            var charactersToUpdate = await GetCharactersDetailedInfo(characterIds);

            foreach (Character c in charactersToUpdate)
            {
                var updated = characters.Where(ch => c.CharacterId == ch.CharacterId).FirstOrDefault();
                c.Experience = updated.Experience;
                c.Name = updated.Name;

                //I'm not sold that this will work out of the box.
                c.BaseStats = updated.BaseStats;
                c.Equipment = updated.Equipment;
            }    
        }

    }
}
