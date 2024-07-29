using Chms.Domain.Entities;

namespace Chms.Application.Common.Interface
{
    public interface IDocumentService
    {
        public Task<Guid> Create(Document entity);
        public Task Update(Document entity);
        public void Delete(string id);
        public List<Document> List();
        public Document Get(string id);
        public int GetTotalData();
    }
}