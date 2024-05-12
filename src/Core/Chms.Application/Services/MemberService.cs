using Chms.Application.Common.Interface;
using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;

namespace Chms.Application.Services;

public class MemberService : IMemberService
{
    public readonly IMemberCommandRepository _command;
    public readonly IMemberQueryRepository _query;
    public MemberService(IMemberCommandRepository commandRepository, IMemberQueryRepository queryRepository)
    {
        _command = commandRepository;
        _query = queryRepository;
    }
    public async Task<Guid> Create(Member entity)
    {
        return await _command.Create(entity);
    }

    public void Delete(int id)
    {
        _command.Delete(id);
    }

    public Member Get(int id)
    {
        return _query.Get(id);
    }

    public List<MemberListVM> List()
    {
        return _query.List();
    }

    public Task Update(Member entity)
    {
        return _command.Update(entity);
    }
}