using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;
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
    public class UserCommandRepository : IUserCommandRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ChMSDbContext _context;

        public UserCommandRepository(ChMSDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

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

        public async Task<bool> UpdatePassword(long id, string password)
        {
             var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return false;
            }
            var pass = password.ToString();
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, pass);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}
