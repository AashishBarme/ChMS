using Chms.Domain.Entities;
using Chms.Domain.ViewModels.Members;

namespace Chms.Application.Common.Interface;

 public interface IIncomeService
    {
        public Task<Guid> Create(Income entity);
        public Task Update(Income entity);
        public Income Get(int id);
        public void Delete(int id);
        public List<Income> List(FilterVm query); 
        public int TotalDataCount(FilterVm query);


    }

public interface IExpenseService
{
    public Task<Guid> Create(Expense entity);
    public Task Update(Expense entity);
    public Expense Get(int id);
    public void Delete(int id);
    public List<Expense> List(FilterVm query);
    public int TotalDataCount(FilterVm query);

}
