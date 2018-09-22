using MurderWithFriendsAPI.DAL.DataAccess.Implementations;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.Services
{
	public class AuthService
	{
        ISecurityData _securityData;
        public AuthService()
        {
            _securityData = new SecurityData();
        }

		public async Task<bool> IsAuthorized(string userName, string password)
		{
            return await _securityData.AttemptLogin(userName, password);		
		}
	}
}
