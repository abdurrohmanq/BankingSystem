using BankingSystem.Service.DTOs.Deposits;

namespace BankingSystem.Service.Interfaces;

public interface IDepositService
{
	Task<DepositResultDto> AddAsync(DepositCreationDto dto);
	Task<DepositResultDto> UpdateAsync(DepositUpdateDto dto);
	Task<bool> DeleteAsync(long id);
	Task<DepositResultDto> GetAsync(long id);
	Task<IEnumerable<DepositResultDto>> GetAllAsync();
}
