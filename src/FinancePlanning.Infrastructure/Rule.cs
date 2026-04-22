using System.ComponentModel.DataAnnotations;

namespace FinancePlanning.Infrastructure;

public class Rule
{
    [Key]
    public int Id { get; set; }
    public required string IncomeSourceCode { get; set; }
    public decimal Amount { get; set; }
    public required string Type { get; set; }
    public required string AccountCode { get; set; }
    
    public IncomeSource IncomeSource { get; set; }
    public Account Account { get; set; }
}