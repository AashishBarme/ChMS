using Chms.Application.Common.Interface.Repositories;


namespace Chms.Infrastructure.Repositories.Document
{
    public class DocumentQueryRepository : IDocumentQueryRepository
    {
        public Domain.Entities.Document Get(string id)
        {
            throw new NotImplementedException();
        }

        public int GetTotalData()
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Document> List()
        {
            throw new NotImplementedException();
        }
    }
}