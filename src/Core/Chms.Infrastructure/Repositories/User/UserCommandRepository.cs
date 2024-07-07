using Chms.Application.Common.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chms.Infrastructure.Repositories.User
{
    internal class UserCommandRepository : IUserCommandRepository
    {
        public Task<Guid> Create(Domain.Entities.User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Update(Domain.Entities.User entity)
        {
            throw new NotImplementedException();
        }
    }
}
