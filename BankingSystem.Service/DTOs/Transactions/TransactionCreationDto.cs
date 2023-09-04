namespace BankingSystem.Service.DTOs.Transactions;

public class TransactionCreationDto
{
	public string Description { get; set; }
	public decimal Amount { get; set; }

	public long SourceAccountId { get; set; }
	public long TargetAccountId { get; set; }
}
