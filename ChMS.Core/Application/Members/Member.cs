using ChMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.Members
{
    public class Member
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SecondaryPhoneNumber { get; set;}
        public string? BirthDate { get; set; }
        public string? Sex { get; set;}
        public string? Occupation { get; set; }
        public string? Photo { get; set; }
        public string? PermanentAddress { get; set; }
        public string? TemporaryAddress { get; set; }
        public int GroupId { get; set; } 
        public ChurchRole ChurchRole { get; set; }
            
    }
}
