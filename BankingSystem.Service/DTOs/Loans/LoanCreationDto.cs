using BankingSystem.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service.DTOs.Loans;

public class LoanCreationDto
{
	public decimal Amount { get; set; }
	public DateTime LoanDate { get; set; }

	public long AccountId { get; set; }
}
