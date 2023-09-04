using BankingSystem.Service.DTOs.Transactions;

namespace BankingSystem.Service.Interfaces;

public interface ITransactionService
{
	Task<TransactionResultDto> AddAsync(TransactionCreationDto dto);
	Task<TransactionResultDto> UpdateAsync(TransactionUpdateDto dto);
	Task<bool> DeleteAsync(long id);
	Task<TransactionResultDto> GetAsync(long id);
	Task<IEnumerable<TransactionResultDto>> GetAllAsync();
}
