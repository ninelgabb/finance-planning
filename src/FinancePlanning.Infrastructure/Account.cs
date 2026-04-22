using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancePlanning.Infrastructure;

public class Account
{
    [Key]
    public required string Code { get; set; }
    public required string BankCode { get; set; }
    public required string Name { get; set; }
    
    // [ForeignKey(nameof(BankCode))]
    public Bank Bank { get; set; }
    
    public virtual ICollection<Distribution> Distributions { get; set; } = [];
    public virtual ICollection<Rule> Rules { get; set; } = [];
}