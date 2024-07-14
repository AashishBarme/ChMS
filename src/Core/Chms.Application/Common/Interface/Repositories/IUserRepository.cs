using Chms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chms.Application.Common.Interface.Repositories
{
    public interface IUserCommandRepository
    {
        public Task<Guid> Create(User entity);
        public Task<Guid> Update(User entity);
        public void Delete(Guid id);
        public Task<bool> UpdatePassword(long id, string password);

    }

    public interface IUserQueryRepository
    {
        public Task<User> GetByUserName(string userName);
        public User Get(Guid id);
        public List<User> List();
    }
}
