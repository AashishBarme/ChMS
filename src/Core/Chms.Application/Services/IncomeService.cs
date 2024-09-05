using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using Chms.Domain.ViewModels.Members;

namespace Chms.Application.Services;

public class IncomeService : IIncomeService
{
   
    public Task<Guid> Create(Income entity)
    {
        throw new NotImplementedException();
    }

   

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Income Get(int id)
    {
        throw new NotImplementedException();
    }


    public List<Income> List(FilterVm query)
    {
        throw new NotImplementedException();
    }

    public int TotalDataCount(FilterVm query)
    {
        throw new NotImplementedException();
    }

    public Task Update(Income entity)
    {
        throw new NotImplementedException();
    }
}