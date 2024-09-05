using Chms.Domain.Entities;
using Chms.Domain.ViewModels.IncomeExpense;

namespace Chms.Application.Common.Interface.Repositories;

public interface IIncomeRepository
{

    public Task<Guid> Create(Income entity);
    public Task Update(Income entity);
    public Income Get(int id);
    public void Delete(int id);
    public List<Income> List(FilterVm query);
    public int TotalDataCount(FilterVm query);
}

public interface IExpenseRepository
{
    public Task<Guid> Create(Expense entity);
    public Task Update(Expense entity);
    public Expense Get(int id);
    public void Delete(int id);
    public List<Expense> List(FilterVm query);
    public int TotalDataCount(FilterVm query);

}