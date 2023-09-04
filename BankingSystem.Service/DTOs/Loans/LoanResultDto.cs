using BankingSystem.Service.DTOs.Accounts;

namespace BankingSystem.Service.DTOs.Loans;

public class LoanResultDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
	public DateTime LoanDate { get; set; }

	public AccountResultDto Account { get; set; }
}
