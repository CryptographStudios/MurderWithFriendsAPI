using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.DAL.DataAccess.Interfaces
{
    public interface ISecurityData
    {

        Task<Security> GetSecurity(long id);

        Task AddSecurity(Security security);

        Task<long> PostSecurity(Security security);

        Task DeleteSecurity(long id);

        Task<bool> AttemptLogin(string userName, string saltedHash);
    }
}
