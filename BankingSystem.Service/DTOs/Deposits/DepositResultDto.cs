using BankingSystem.Domain.Entities.Accounts;

namespace BankingSystem.Service.DTOs.Deposits;

public class DepositResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
	public DateTime DepositDate { get; set; }

	public Account Account { get; set; }
}
