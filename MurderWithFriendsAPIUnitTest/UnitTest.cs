//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MurderWithFriendsAPI.Models;
//using MurderWithFriendsAPI.Services;
//using System;

//namespace MurderWithFriendsAPIUnitTest
//{
//	[TestClass]
//	public class DBUnitTests
//	{
//		[TestMethod]
//		public void TestGetUser()
//		{		
//			using (var context = new ItsOnlyHeroesContext())
//			{
//				var expectedUserName = "Matt";
//				var heroUser = context.User.Find(1L);

//				Assert.AreEqual(expectedUserName, heroUser.UserName);
//			}
//		}

//		[TestMethod]
//		public void TestAddUser()
//		{
//			User newUser = new User();

//			newUser.Active = true;
//			newUser.DisplayName = "MCubed";
//			newUser.LastLogin = DateTime.UtcNow;
//			newUser.UserName = "Matt";
			

//			using (var context = new ItsOnlyHeroesContext())
//			{
//				var heroUser = context.User.Add(newUser);
//				context.SaveChanges();
//				Assert.IsNotNull(heroUser.Entity.UserId);
//				Assert.IsTrue(heroUser.Entity.UserId > 0);
//			}
//		}
//        [TestMethod]
//        public void  CanGetAttackValue()
//        {
//            var dmgService = new DamageService();
//            int testVal = dmgService.GetAttackValue(8);
//            Assert.IsTrue(testVal > 0);
//        }
//	}
//}
