using ChMS.Core.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? MiddleName { get; set; } = null;
        [MaxLength(50)]
        public string? LastName { get; set; }
        public UserGroup UserGroup { get; set; }
        public ActiveStatus IsActive { get; set; }
    }
}
