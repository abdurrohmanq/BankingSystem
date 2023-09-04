using AutoMapper;
using BankingSystem.Data.IRepositories;
using BankingSystem.Domain.Entities.Loans;
using BankingSystem.Service.DTOs.Loans;
using BankingSystem.Service.Exceptions;
using BankingSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Domain.Entities.Accounts;

namespace BankingSystem.Service.Services;

public class LoanService : ILoanService
{
	private readonly IRepository<Loan> repository;
	private readonly IRepository<Account> accountRepository;
	private readonly IMapper mapper;
	public LoanService(IRepository<Loan> repository, IMapper mapper, IRepository<Account> accountRepository)
	{
		this.repository = repository;
		this.mapper = mapper;
		this.accountRepository = accountRepository;
	}
	public async Task<LoanResultDto> AddAsync(LoanCreationDto dto)
	{
		var existCustomer = await accountRepository.GetAsync(c => c.Id.Equals(dto.AccountId))
			?? throw new NotFoundException("Account not found");

		var mappedLoan = mapper.Map<Loan>(dto);
		await repository.CreateAsync(mappedLoan);
		await repository.SaveChanges();

		return mapper.Map<LoanResultDto>(mappedLoan);
	}

	public async Task<bool> DeleteAsync(long id)
	{
		var existLoan = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Loan not found");

		repository.Delete(existLoan);
		await repository.SaveChanges();

		return true;
	}

	public async Task<IEnumerable<LoanResultDto>> GetAllAsync()
	{
		var allLoans = await repository.GetAll().ToListAsync();

		return mapper.Map<IEnumerable<LoanResultDto>>(allLoans);
	}

	public async Task<LoanResultDto> GetAsync(long id)
	{
		var existLoan = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Loan not found");

		return mapper.Map<LoanResultDto>(existLoan);
	}

	public async Task<LoanResultDto> UpdateAsync(LoanUpdateDto dto)
	{
		var existLoan = await repository.GetAsync(c => c.Id == dto.Id)
			?? throw new NotFoundException("This Loan not found");

		mapper.Map(dto, existLoan);
		repository.Update(existLoan);
		await repository.SaveChanges();

		return mapper.Map<LoanResultDto>(existLoan);
	}
}
