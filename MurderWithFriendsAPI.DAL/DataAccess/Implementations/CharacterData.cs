using MurderWithFriendsAPI.DAL.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MurderWithFriendsAPI.DAL.DataAccess.Implementations
{
    //these should all be async later. I'm being lazy.
    public class CharacterData
    {
        private readonly ItsOnlyHeroesContext _dbContext;

        public CharacterData(ItsOnlyHeroesContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Character> GetCharactersBasicInfo(List<long> characterIds)
        {
            var characters = _dbContext.Character
                                        .Where(c => characterIds.Contains(c.CharacterId)).ToList();

            return characters;
        }

        public IEnumerable<Character> GetCharactersDetailedInfo(List<long> characterIds)
        {
            var characters = _dbContext.Character
                                        .Where(c => characterIds.Contains(c.CharacterId))
                                        .Include( c => c.Experience)
                                        .Include( c=> c.Equipment.Select( e => e.Item))
                                        .ToList();

            return characters;
        }

        public void AddOrUpdateCharacters(IEnumerable<Character> characters)
        {
            var newCharacters = characters.Where(c => c.CharacterId == 0).ToList();
            var updatedCharacters = characters.Where(c => c.CharacterId == 0).ToList();

            AddCharacters(newCharacters);
            
        }

        private void AddCharacters(IEnumerable<Character> characters)
        {
            _dbContext.Character.AddRange(characters);
            _dbContext.SaveChanges();
        }

        private void UpdateCharacters(IEnumerable<Character> characters)
        {
            var characterIds = characters.Select(c => c.CharacterId).ToList();
            var charactersToUpdate = GetCharactersDetailedInfo(characterIds);

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
