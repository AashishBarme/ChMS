using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface;

 public interface IMemberService
    {
        public Task<Guid> Create(Member entity);
        public Task Update(Member entity);
        public Member Get(string id);
        public void Delete(string id);
        public List<MemberListVM> List(); 


    }
