using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;
using Chms.Infrastructure.DataAccess;
using Chms.Infrastructure.Persistence;

namespace Chms.Infrastructure;

public class InventoryQueryRepository : IInventoryQueryRepository
{
    public readonly BaseRepository _baseRepository;
    public const string TABLE_NAME = "inventories";
    public InventoryQueryRepository(BaseRepository baseRepository)
    {
        _baseRepository = baseRepository;
    }

    public Inventory Get(int id)
    {
          string sql = $"select * from {TABLE_NAME} where Id = @Id";
            return _baseRepository.LoadSingleData<Inventory, object>(sql, new { Id = id })
                    .GetAwaiter().GetResult();
        throw new NotImplementedException();
    }

    public List<Inventory> List()
    {
           string sql = $"select * from {TABLE_NAME} order by CreatedDate DESC";
            return _baseRepository.LoadData<Inventory, object>(sql, new { }).GetAwaiter().GetResult();
    }
}