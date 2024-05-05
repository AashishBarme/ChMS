using Chms.Application.Common.Interface;
using Chms.Domain.Entities;

namespace Chms.Application.Services;

public class MemberService : IMemberService
{
    public Task<Guid> Create(Member entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Member Get(string id)
    {
        throw new NotImplementedException();
    }

    public List<MemberListVM> List()
    {
        throw new NotImplementedException();
    }

    public Task Update(Member entity)
    {
        throw new NotImplementedException();
    }
}