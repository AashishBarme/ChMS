using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;
using Chms.Domain.ViewModels.IncomeExpense;
using Chms.Infrastructure.DataAccess;
using Chms.Infrastructure.Persistence;

namespace Chms.Infrastructure;

public class IncomeRepository : IIncomeRepository
{
    public readonly ChMSDbContext _dbContext;
    public readonly BaseRepository _baseRepository;
    public IncomeRepository(ChMSDbContext dbContext, BaseRepository baseRepository)
    {
        _dbContext = dbContext;
        _baseRepository = baseRepository;
    }
    public async Task<int> Create(Inventory entity)
    {
        _dbContext.Inventories.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task<Guid> Create(Income entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        string sql = "delete from `inventories` where Id = @Id";
        _baseRepository.LoadData<string, object>(sql, new { Id = id }).GetAwaiter().GetResult();
    }

    public Income Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Income> List(FilterVm query)
    {
        throw new NotImplementedException();
    }

    public int TotalDataCount(FilterVm query)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Update(Inventory entity)
    {
        _dbContext.Inventories.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public Task Update(Income entity)
    {
        throw new NotImplementedException();
    }
}