using Chms.Application.Common.Interface.Repositories;
using Chms.Infrastructure.DataAccess;
using Chms.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Chms.Infrastructure.Repositories.Member;

public class MemberCommandRepository : IMemberCommandRepository
{
    public readonly ChMSDbContext _dbContext;
    public readonly BaseRepository _baseRepo;
    public const string TABLE_NAME = "member";
    public MemberCommandRepository(ChMSDbContext dbContext, BaseRepository baseRepo)
    {
        _dbContext = dbContext;
        _baseRepo = baseRepo;
    }
    public async Task<Guid> Create(Domain.Entities.Member entity)
    {
        _dbContext.Members.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public void Delete(int id)
    {
        string sql = $"delete from {TABLE_NAME} where Id = @Id";
        _baseRepo.LoadData<string, object>(sql, new { Id = id }).GetAwaiter().GetResult();
    }

    public async Task<Guid> Update(Domain.Entities.Member entity)
    {
        _dbContext.Members.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }
}