using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChMS.Core.Infrastructure.DataAccess;
using ChMS.Core.Infrastructure.Persistence;

namespace ChMS.Core.Application.Members
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ChMSDbContext _dbContext;
        private readonly BaseRepository _baseRepo;

        public MemberRepository(ChMSDbContext dbContext, BaseRepository baseRepo)
        {
            _dbContext = dbContext;
            _baseRepo = baseRepo;
        }

        public const string tableName = "members";


        public async Task<Guid> Create(Member entity)
        {
            _dbContext.Members.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
          
        }

        public void Delete(string id)
        {
            string sql = $"delete from {tableName} where Id = @Id";
            _baseRepo.LoadData<string, object>(sql, new{Id = id}).GetAwaiter().GetResult();
        }

        public Member Get(string id)
        {
            string sql = $"select * from {tableName} where Id = @Id";
           return _baseRepo.LoadSingleData<Member, object>(sql, new{Id = id}).GetAwaiter().GetResult();
        }

        public async Task Update(Member entity)
        {
              _dbContext.Members.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public List<MemberListVM> List()
        {
            string sql = $"select Id, FirstName, LastName, Email, PhoneNumber, Gender, GroupId, ChurchRole from {tableName} order by CreatedDate DESC";
            return _baseRepo.LoadData<MemberListVM, object>(sql, new{}).GetAwaiter().GetResult();
        }
    }
}
