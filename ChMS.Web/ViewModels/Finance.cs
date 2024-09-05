namespace ChMS.Web.ViewModels
{
    public class Income
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; } = 0;
        public string? Description { get; set; }
    }

    public class AddIncome
    {
        public DateTime Date { get; set; }
        public List<Income> Income { get; set; } = new();
    }

    public class ListIncome
    {
        public List<Income> Income { get; set; } = new();
    }

    public class EditIncome : AddIncome
    {
        public Guid Id {get; set;}
    }

    public class IncomeFilterQueryVm
    {
        public DateTime Date { get; set; }
        public int Limit { get; set; } = 20;
        public int Offset { get; set; } = 0;
    }


}