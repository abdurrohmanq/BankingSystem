using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service.DTOs.Accounts;

public class AccountCreationDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string AccountNumber { get; set; }
	public decimal Balance { get; set; }
}
