using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;
using Chms.Infrastructure.DataAccess;
using Chms.Infrastructure.Identity;
using Chms.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chms.Infrastructure.Repositories.User
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ChMSDbContext _context;
        private readonly BaseRepository _baseRepository;
        public const string TABLE_NAME = "users";

        public UserQueryRepository(ChMSDbContext context, UserManager<ApplicationUser> userManager, BaseRepository baseRepository)
        {
            _context = context;
            _userManager = userManager;
            _baseRepository = baseRepository;
        }

        public Domain.Entities.User Get(Guid id)
        {

            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.User> GetByUserName(string userName)
        {
            var returnUser = await _userManager.FindByNameAsync(userName);

            if (returnUser != null)
            {
                return new Domain.Entities.User
                {
                    Id = returnUser.Id,
                    Email = returnUser.Email,
                    UserName = returnUser.UserName,
                    FirstName = returnUser.FirstName,
                    MiddleName = returnUser.MiddleName,
                    LastName = returnUser.LastName
                };
            }
            throw new Exception();
        }

        public List<Domain.Entities.User> List()
        {
             var sql = @$"select Username, Email,Status,UserType,Id from `{TABLE_NAME}`";
            var where = new { };
            var result = _baseRepository.LoadData<Domain.Entities.User, object>(sql, where).GetAwaiter().GetResult();
            return result;
        }
    }
}
