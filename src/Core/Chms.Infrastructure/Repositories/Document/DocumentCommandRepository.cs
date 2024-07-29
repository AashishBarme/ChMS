using Chms.Application.Common.Interface.Repositories;

namespace Chms.Infrastructure.Repositories.Document;

public class DocumentCommandRepository : IDocumentCommandRepository
{
    public Task<Guid> Create(Domain.Entities.Document entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Domain.Entities.Document entity)
    {
        throw new NotImplementedException();
    }
}