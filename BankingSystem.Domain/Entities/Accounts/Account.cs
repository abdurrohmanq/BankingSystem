using BankingSystem.Domain.Commons;
using BankingSystem.Domain.Entities.Deposits;
using BankingSystem.Domain.Entities.Loans;
using BankingSystem.Domain.Entities.Transactions;
using System.Text.Json.Serialization;

namespace BankingSystem.Domain.Entities.Accounts;

public class Account : AudiTable
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string AccountNumber { get; set; }
	public decimal Balance { get; set; }

	[JsonIgnore]
	public ICollection<Deposit> Deposits { get; set; }
	[JsonIgnore]
	public ICollection<Loan> Loans { get; set; }
	[JsonIgnore]
	public ICollection<Transaction> SendTransactions { get; set; }
	[JsonIgnore]
	public ICollection<Transaction> ReceiveTransactions { get; set; }
}
