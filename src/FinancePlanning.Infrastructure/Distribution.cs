using System.ComponentModel.DataAnnotations;

namespace FinancePlanning.Infrastructure;

public class Distribution
{
    [Key] public int Id { get; set; }
    public int IncomeId { get; set; }
    public required string AccountCode { get; set; }
    public decimal Amount { get; set; }

    public Income Income { get; set; }
    public Account Account { get; set; }
}