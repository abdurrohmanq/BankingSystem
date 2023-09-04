using BankingSystem.Domain.Commons;
using BankingSystem.Domain.Entities.Accounts;

namespace BankingSystem.Domain.Entities.Transactions;

public class Transaction : AudiTable
{
	public string Description { get; set; }
	public decimal Amount { get; set; }

	public long SourceAccountId { get; set; } 
	public long TargetAccountId { get; set; }

	public Account SourceAccount { get; set; }
	public Account TargetAccount { get; set; }
}
