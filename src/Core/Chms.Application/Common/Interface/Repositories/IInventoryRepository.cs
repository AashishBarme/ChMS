using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface.Repositories;

public interface IInventoryCommandRepository
{
    public Task<int> Create(Inventory entity);
    public Task<int> Update(Inventory entity);
    public void Delete(int id);
}

public interface IInventoryQueryRepository
{
    public Inventory Get(int id);
    public List<Inventory> List();
}