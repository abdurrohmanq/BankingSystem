using BankingSystem.Service.DTOs.Loans;

namespace BankingSystem.Service.Interfaces;

public interface ILoanService
{
	Task<LoanResultDto> AddAsync(LoanCreationDto dto);
	Task<LoanResultDto> UpdateAsync(LoanUpdateDto dto);
	Task<bool> DeleteAsync(long id);
	Task<LoanResultDto> GetAsync(long id);
	Task<IEnumerable<LoanResultDto>> GetAllAsync();
}
