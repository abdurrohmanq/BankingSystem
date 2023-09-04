using BankingSystem.Domain.Commons;
using BankingSystem.Domain.Entities.Accounts;

namespace BankingSystem.Domain.Entities.Deposits;

public class Deposit : AudiTable
{
	public decimal Amount { get; set; }
	public DateTime DepositDate { get; set; }

	public long AccountId { get; set; }
	public Account Account { get; set; }
}
