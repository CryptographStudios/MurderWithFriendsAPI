using MurderWithFriendsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.Services
{
	public class AuthService
	{
		public bool IsAuthorized(string userName, string password)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)) return false;

			using (var context = new ItsOnlyHeroesContext())
			{
				int userCount = context.Security.Where(x => x.User.UserName == userName && x.SaltedHash == password).Count();
				return (userCount == 1);
			}			
		}
	}
}
