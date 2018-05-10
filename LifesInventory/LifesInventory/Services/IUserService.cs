using LifesInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LifesInventory.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task RemoveUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
