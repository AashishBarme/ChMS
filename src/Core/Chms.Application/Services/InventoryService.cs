using Chms.Application.Common.Interface;
using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;

namespace Chms.Application.Services;
public class InventoryService : IInventoryService
{
    public readonly IInventoryCommandRepository _command;
    public readonly IInventoryQueryRepository _query;
    public InventoryService(IInventoryCommandRepository commandRepository, IInventoryQueryRepository quereyRepository)
    {
        _command = commandRepository;
        _query = quereyRepository;
    }
    public async Task<int> Create(Inventory entity)
    {
        return await _command.Create(entity);
    }

    public void Delete(int id)
    {
        _command.Delete(id);
    }

    public Inventory Get(int id)
    {
        return  _query.Get(id);
    }

    public List<Inventory> List()
    {
        return _query.List();
    }

    public Task Update(Inventory entity)
    {
        return _command.Update(entity);
    }
}