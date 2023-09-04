using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service.DTOs.Deposits;

public class DepositCreationDto
{
	public decimal Amount { get; set; }
	public DateTime DepositDate { get; set; }

	public long AccountId { get; set; }
}
