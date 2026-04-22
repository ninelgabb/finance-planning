using System.ComponentModel.DataAnnotations;

namespace FinancePlanning.Infrastructure;

public class Income
{
    [Key]
    public int Id { get; set; }
    public required string IncomeSourceCode { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string? Comment { get; set; }

    public virtual ICollection<Distribution> Distributions { get; set; } = [];
    
    public IncomeSource IncomeSource { get; set; }
}