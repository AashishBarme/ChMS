using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.Members
{
    public interface IMemberRepository
    {
        public Task<Guid> Create(Member entity);
        public Task Update(Member entity);
        public Member Get(string id);
        public void Delete(string id);
        public List<MemberListVM> List(); 


    }
}
