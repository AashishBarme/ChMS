namespace Chms.Domain.Entities;

public class Income : BaseModel
{
    public int Id { get; set; }
    public string? Category { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public int MemberId { get; set; }
    public string? Description { get; set; }
}

public class Expense : BaseModel
{
    public int Id { get; set; }
    public string? Category { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
}