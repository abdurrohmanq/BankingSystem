namespace BankingSystem.Service.DTOs.Loans;

public class LoanUpdateDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
	public DateTime LoanDate { get; set; }

	public long AccountId { get; set; }
}
