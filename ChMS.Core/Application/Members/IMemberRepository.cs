using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChMS.Core.Application.Members
{
    public interface IMemberRepository
    {
        public Guid Create(Member entity);
        public void Update(Member entity);
        public Member Get(string id);
        public void Delete(string id);


    }
}
