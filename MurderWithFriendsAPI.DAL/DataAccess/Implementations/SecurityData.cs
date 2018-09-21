using Microsoft.EntityFrameworkCore;
using MurderWithFriendsAPI.DAL.DataAccess.Interfaces;
using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.DAL.DataAccess.Implementations
{
    class SecurityData : ISecurityData
    {
        private readonly ItsOnlyHeroesContext _dBContext;

        public SecurityData(ItsOnlyHeroesContext context)
        {
            _dBContext = context;
        }

        //public Task<IEnumerable<Security>> GetSecurity()
        //{
        //    return _dBContext.Security;
        //}

        public async Task<Security> GetSecurity(long id)
        { 
            var security =  await _dBContext.Security.FindAsync(id);
            return security;
        }

        public async Task AddSecurity(Security security)
        {


            _dBContext.Entry(security).State = EntityState.Modified;

            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }

    public async Task<long> PostSecurity(Security security)
        {
            _dBContext.Security.Add(security);
            await _dBContext.SaveChangesAsync();

            return security.SecurityId;
        }

        public async Task DeleteSecurity(long id)
        {

            var security =  await _dBContext.Security.FindAsync(id);
            if (security == null)
            {
                return;
            }

            _dBContext.Security.Remove(security);
            await _dBContext.SaveChangesAsync();
        }

        private async Task<bool> SecurityExists(long id)
        {
            return await _dBContext.Security.AnyAsync(e => e.SecurityId == id);
        }

        public async Task<bool> AttemptLogin(string userName, string saltedHash)
        {
            return await _dBContext.Security.Where(x => x.User.UserName == userName && x.SaltedHash == saltedHash).AnyAsync();
        }

    }
}

