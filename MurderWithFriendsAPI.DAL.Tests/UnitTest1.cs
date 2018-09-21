using Microsoft.VisualStudio.TestTools.UnitTesting;
using MurderWithFriendsAPI.DAL.DataAccess.Implementations;
using MurderWithFriendsAPI.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MurderWithFriendsAPI.DAL.Tests
{
    [TestClass]
    public class CharacterDataTests
    {
        CharacterData _data;

        public CharacterDataTests()
        {
            _data = new CharacterData();
        }

        [TestMethod]
        public async void TestGetCharacter()
        {

            List<long> charIds = new List<long> { 8 };

            var characters = (await _data.GetCharactersBasicInfo(charIds)).ToList();

            Assert.IsTrue(characters.Count > 0);
        }

        [TestMethod]
        public async void TestAddCharacter()
        {
            var character = BuildTestCharacter();
            List<Character> characters = new List<Character> { character };

            await _data.AddOrUpdateCharacters(characters);

            Assert.IsTrue(character.CharacterId > 0);
        }

        [TestMethod]
        public async void TestUpdateCharacter()
        {
            List<long> charIds = new List<long> { 8 };
            var character = (await _data.GetCharactersBasicInfo(charIds)).FirstOrDefault();
            Assert.IsNotNull(character);

            var expectedName = character.Name + 'y';
            character.Name = expectedName;
            
            List<Character> characters = new List<Character> { character };
            await _data.AddOrUpdateCharacters(characters);

            var updatedCharacter = _data.GetCharactersBasicInfo(charIds);

            Assert.AreEqual(character.Name, expectedName);
        }

        private Character BuildTestCharacter()
        {
            Character character = new Character();
            character.Name = "Test Character";
            character.BaseStats = new Stats();
            character.BaseStats.Strength = 15;
            character.BaseStats.Dexterity = 15;
            character.BaseStats.Agility = 15;
            character.BaseStats.Wisdom = 15;
            character.BaseStats.Intelligence = 15;
            character.BaseStats.Charisma = 15;
            character.BaseStats.Constitution = 15;
            character.BaseStats.ElectricBonus = 15;
            character.BaseStats.WaterBonus = 15;
            character.BaseStats.FireBonus = 15;
            character.BaseStats.EarthBonus = 15;
            character.BaseStats.HolyBonus = 15;
            character.BaseStats.DarkBonus = 15;
            character.BaseStats.Armor = 15;
            character.BaseStats.MagicResist = 15;
            character.BaseStats.ArmorPenetration = 15;
            character.BaseStats.MagicPenetration = 15;
            character.Experience = new Experience();
            character.Experience.Amount = 999;
            character.Experience.CurrentLevel = 10;
            return character;
        }
    }
}
