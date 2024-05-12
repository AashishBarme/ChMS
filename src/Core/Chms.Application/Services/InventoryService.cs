using Chms.Application.Common.Interface;
using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;

namespace Chms.Application.Services;
public class InventoryService : IInventoryService
{
    public readonly IInventoryCommandRepository _commandRepo;
    public readonly IInventoryQueryRepository _queryRepo;
    public InventoryService(IInventoryCommandRepository commandRepository, IInventoryQueryRepository quereyRepository)
    {
        _commandRepo = commandRepository;
        _queryRepo = quereyRepository;
    }
    public async Task<int> Create(Inventory entity)
    {
        return await _commandRepo.Create(entity);
    }

    public void Delete(int id)
    {
        _commandRepo.Delete(id);
    }

    public Inventory GetAsync(int id)
    {
        return  _queryRepo.Get(id);
    }

    public List<Inventory> List()
    {
        return _queryRepo.List();
    }

    public Task Update(Inventory entity)
    {
        return _commandRepo.Update(entity);
    }
}