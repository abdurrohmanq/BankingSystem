using BankingSystem.Service.DTOs.Accounts;

namespace BankingSystem.Service.Interfaces;

public interface IAccountService
{
	Task<AccountResultDto> AddAsync(AccountCreationDto dto);
	Task<AccountResultDto> UpdateAsync(AccountUpdateDto dto);
	Task<bool> DeleteAsync(long id);
	Task<AccountResultDto> GetAsync(long id);
	Task<IEnumerable<AccountResultDto>> GetAllAsync();
	Task<bool> TransferFunds(long sourceAccountId, long targetAccountId,decimal amount);
}
