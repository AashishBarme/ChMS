using ChMS.Core.Application.Families;
using ChMS.Core.Application.Members;
using ChMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.MembFamilyRelation
{
    public class MemberFamilyRelation
    {
        public int Id { get; set; }
        public Member Member { get; set; } 
        public Guid MemberId { get; set; }
        public Family Family { get; set; }
        public int FamilyId { get; set; }
        public Relation Relation { get; set; }
    }
}
