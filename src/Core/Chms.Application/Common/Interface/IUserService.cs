using Chms.Domain.ViewModels.Users;

namespace Chms.Application.Common.Interface;

    public interface IUsersService
    {
        Task<long> Create(CreateUserVm entity);
        Task Update(EditUserVm entity);
        Task<bool> Delete(long id);
        Task<GetUsersQueryVm> GetUsers(GetUsersQueryDto query);
        Task<Dictionary<long, string>> ListAllUsers();
        Task<Dictionary<long, string>> ListUsersIdAndUsername();
        // Task UpdateUserPassword(UserPasswordChangeViewModel request);
        Task<UserDetailsVm> Get(long id);
        Task<long> GetIdByUsername(string username);
    }