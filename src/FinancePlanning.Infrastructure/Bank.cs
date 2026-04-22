using System.ComponentModel.DataAnnotations;

namespace FinancePlanning.Infrastructure;

public class Bank
{
    [Key]
    public required string Code { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = [];
}