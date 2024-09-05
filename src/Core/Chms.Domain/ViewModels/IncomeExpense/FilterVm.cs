using Chms.Domain.ViewModels;

namespace Chms.Domain.ViewModels.IncomeExpense
{
    public class FilterVm : BaseVm
    {
        public DateTime? DateTime {get; set;}
        public string? PhoneNumber {get; set;}
        public string? Gender {get; set;}
    }
}