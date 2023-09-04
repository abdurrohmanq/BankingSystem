namespace BankingSystem.Service.DTOs.Transactions;

public class TransactionUpdateDto
{
    public long Id { get; set; }
    public string Description { get; set; }
	public decimal Amount { get; set; }

	public long SourceAccountId { get; set; }
	public long TargetAccountId { get; set; }
}
