using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface.Repositories;
   
public interface IMemberCommandRepository
{
    public Task<Guid> Create(Member entity);
    public Task<Guid> Update(Member entity);
    public void Delete(int id);

}

public interface IMemberQueryRepository
{
    public Member Get(int id);
    public List<MemberListVM> List(); 
}