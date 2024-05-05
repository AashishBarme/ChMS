using Chms.Application.Common.Interface;
using Chms.Domain.ViewModels.Users;

namespace Chms.Application.Services;

public class UserService : IUsersService
{
    public Task<long> Create(CreateUserVm entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetailsVm> Get(long id)
    {
        throw new NotImplementedException();
    }

    public Task<long> GetIdByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public Task<GetUsersQueryVm> GetUsers(GetUsersQueryDto query)
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<long, string>> ListAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<long, string>> ListUsersIdAndUsername()
    {
        throw new NotImplementedException();
    }

    public Task Update(EditUserVm entity)
    {
        throw new NotImplementedException();
    }
}
