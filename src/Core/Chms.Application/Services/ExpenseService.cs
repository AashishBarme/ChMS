using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using Chms.Domain.ViewModels.IncomeExpense;

namespace Chms.Application.Services;

public class ExpenseService : IExpenseService
{
   

    public Task<int> Create(Expense entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }


    public Task Update(Expense entity)
    {
        throw new NotImplementedException();
    }

    public Expense Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Expense> List(FilterVm query)
    {
        throw new NotImplementedException();
    }

    public int TotalDataCount(FilterVm query)
    {
        throw new NotImplementedException();
    }
}