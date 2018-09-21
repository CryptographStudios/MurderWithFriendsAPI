using Microsoft.AspNetCore.Mvc;
using MurderWithFriendsAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MurderWithFriendsAPI.DAL.DataAccess.Interfaces
{
    public interface IUserData
    {
        Task<User> GetUser(long id);

        Task<IActionResult> AddOrUpdateUser(User user);

        Task<IActionResult> DeleteUser(long id);

        Task<bool> UserExists(long id);
    }
}
