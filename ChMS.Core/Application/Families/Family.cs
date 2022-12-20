using ChMS.Core.Application.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.Families
{
    public class Family
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public Member FamilyHead { get; set; }
        public string PermanentAddress { get; set; }
        public string TemporaryAddress { get; set; }
    }
}
