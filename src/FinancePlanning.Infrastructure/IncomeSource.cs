using System.ComponentModel.DataAnnotations;

namespace FinancePlanning.Infrastructure;

public class IncomeSource
{
    [Key]
    public required string Code { get; set; }
    public string? PersonName { get; set; }
    public required string Type { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<Income> Incomes { get; set; } = [];
    public virtual ICollection<Rule> Rules { get; set; } = [];
}