namespace ChMS.Core.Application.Families
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly ChMSDbContext _dbContext;
        private readonly BaseRepository _baseRepo;
        private const string tableName = "families";
        public FamilyRepository(ChMSDbContext dbContext, BaseRepository baseRepo)
        {
            _dbContext = dbContext;
            _baseRepo = baseRepo;
        }
        public async Task<int> Create(Family entity)
        {
            _dbContext.Families.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public void Delete(int id)
        {
            string sql = $"delete from {tableName} where Id = @Id";
            _baseRepo.LoadData<string, object>(sql, new{Id = id}).GetAwaiter().GetResult();
        }

        public Family Get(int id)
        {
            string sql = $"select * from {tableName} where Id = @Id";
            return _baseRepo.LoadSingleData<Family, object>(sql, new{Id = id}).GetAwaiter().GetResult();
        }

        public List<Family> List()
        {
            string sql = $"select * from {tableName}";
            return _baseRepo.LoadData<Family, object>(sql, new{}).GetAwaiter().GetResult();
        }

        public async Task Update(Family entity)
        {
            _dbContext.Families.Update(entity);
            await _dbContext.SaveChangesAsync();   
        }
    }
}