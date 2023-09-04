using BankingSystem.Domain.Commons;
using BankingSystem.Domain.Entities.Accounts;

namespace BankingSystem.Domain.Entities.Loans;

public class Loan : AudiTable
{
	public decimal Amount { get; set; }
    public DateTime LoanDate { get; set; }

    public long AccountId { get; set; }
    public Account Account { get; set; }
}
