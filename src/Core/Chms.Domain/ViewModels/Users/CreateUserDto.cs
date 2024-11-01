﻿using Chms.Domain.Common.Enums;

namespace Chms.Domain.ViewModels.Users
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserGroup UserGroup { get; set; }
        public ActiveStatus IsActive { get; set; }

    }
}
