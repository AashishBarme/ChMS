using Chms.Application.Common.Interface.Repositories;
using Chms.Domain.Entities;
using Chms.Infrastructure.DataAccess;
using Chms.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chms.Infrastructure.Repositories.Member
{
    public class MemberQueryRepository : IMemberQueryRepository
    {
        private readonly BaseRepository _baseRepository;
        public const string TABLE_NAME = "member";
        public MemberQueryRepository(BaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public Domain.Entities.Member Get(int id)
        {
            string sql = $"select * from {TABLE_NAME} where Id = @Id";
            return _baseRepository.LoadSingleData<Domain.Entities.Member, object>(sql, new { Id = id })
                    .GetAwaiter().GetResult();
        }

        public List<MemberListVM> List()
        {
            string sql = $"select Id, FirstName, LastName, Email, PhoneNumber, Sex, GroupId, ChurchRole from {TABLE_NAME} order by CreatedDate DESC";
            return _baseRepository.LoadData<MemberListVM, object>(sql, new { }).GetAwaiter().GetResult();
        }
    }
}
