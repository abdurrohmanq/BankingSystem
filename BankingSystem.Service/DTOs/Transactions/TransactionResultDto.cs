using BankingSystem.Service.DTOs.Accounts;
using System.ComponentModel;

namespace BankingSystem.Service.DTOs.Transactions;

public class TransactionResultDto
{
    public long Id { get; set; }
    public string Description { get; set; }
	public decimal Amount { get; set; }
	[DisplayName("Source Account")]

	public AccountResultDto SourceAccount { get; set; }
    [DisplayName("Target Account")]

    public AccountResultDto TargetAccount { get; set; }
    public DateTime CreatedAt { get; set; }
}
