using ChMS.Core.Infrastructure.DataAccess;
using ChMS.Core.Infrastructure.Persistence;

namespace ChMS.Core.Application.Groups
{
    public class GroupRepository : IGroupRepository
    {

        private readonly ChMSDbContext _dbContext;
        private readonly BaseRepository _baseRepo;

        public GroupRepository(ChMSDbContext dbContext, BaseRepository baseRepo)
        {
            _dbContext = dbContext;
            _baseRepo = baseRepo;
        }

        private const string tableName = "groups";
        public async Task<int> Create(Group entity)
        {
            _dbContext.Groups.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public void Delete(int id)
        {
            string sql = $"delete from {tableName} where Id = @Id";
            _baseRepo.LoadData<string, object>(sql, new {Id = id}).GetAwaiter().GetResult();

        }

        public Group Get(int id)
        {
            string sql = $"select * from {tableName} where Id = @Id";
            return _baseRepo.LoadSingleData<Group, object>(sql, new { Id = id}).GetAwaiter().GetResult();
            
        }

        public List<Group> List()
        {
            string sql = $"select * from {tableName}";
            return _baseRepo.LoadData<Group, object>(sql, new{}).GetAwaiter().GetResult();
        }

        public async Task Update(Group entity)
        {
           _dbContext.Groups.Update(entity);
           await _dbContext.SaveChangesAsync();
        }
    }
}