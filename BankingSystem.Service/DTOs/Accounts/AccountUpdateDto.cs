namespace BankingSystem.Service.DTOs.Accounts;

public class AccountUpdateDto
{
    public long Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string AccountNumber { get; set; }
	public decimal Balance { get; set; }

}
