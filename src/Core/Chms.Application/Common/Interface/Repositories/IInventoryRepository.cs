using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface.Repositories;

public interface IInventoryCommandRepository
{
    public Task<int> Create(Inventory entity);
    public bool Update(Inventory entity);
    public bool Delete(int id);
}

public interface IInventoryQueryRepository
{
    public Task<Inventory> Get(int id);
    public Task<List<Inventory>> List();
}