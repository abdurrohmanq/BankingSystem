namespace BankingSystem.Service.DTOs.Deposits;

public class DepositUpdateDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
	public DateTime DepositDate { get; set; }

	public long AccountId { get; set; }
}
