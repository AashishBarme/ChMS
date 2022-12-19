using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.Users
{
    public interface IIdentityService
    {
        Task<long> CreateUserAsync(User user, string password);

        Task<long> CreateUserAsync(User user, string password, string[] permissions);
        Task<User> GetUserByUsername(string username);

        Task<User> GetUserById(long id);
        Task<List<User>> ListAllUsers();
        Task UpdateUserAsync(User entity);
        Task UpdatePasswordAsync(long id, string password);
        Task<bool> DeleteUserAsync(long id);
    }
}
