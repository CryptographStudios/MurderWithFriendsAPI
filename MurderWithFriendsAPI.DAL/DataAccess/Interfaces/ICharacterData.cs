using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.DAL.DataAccess.Interfaces
{
    //This should be modified to fit an asyc pattern later.
    public interface ICharacterData
    {
        Task<IEnumerable<Character>> GetCharactersBasicInfo(List<long> characterIds);
        Task<IEnumerable<Character>> GetCharactersDetailedInfo(List<long> characterIds);
        Task AddOrUpdateCharacters(IEnumerable<Character> characters);
    }
}
