using Chms.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chms.Domain.Entities;
    public class User
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public UserGroup UserGroup { get; set; }
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; } = null;
        public string? LastName { get; set; }
        public ActiveStatus IsActive { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }
    }

