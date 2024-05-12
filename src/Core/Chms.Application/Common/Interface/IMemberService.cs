using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface;

 public interface IMemberService
    {
        public Task<Guid> Create(Member entity);
        public Task Update(Member entity);
        public Member Get(int id);
        public void Delete(int id);
        public List<MemberListVM> List(); 


    }
