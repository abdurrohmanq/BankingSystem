using AutoMapper;
using BankingSystem.Data.IRepositories;
using BankingSystem.Domain.Entities.Transactions;
using BankingSystem.Service.DTOs.Transactions;
using BankingSystem.Service.Exceptions;
using BankingSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using BankingSystem.Domain.Entities.Accounts;

namespace BankingSystem.Service.Services;

public class TransactionService : ITransactionService
{
	private readonly IRepository<Transaction> repository;
	private readonly IRepository<Account> accountRepository;
	private readonly IMapper mapper;
	public TransactionService(IRepository<Transaction> repository, IMapper mapper, IRepository<Account> accountRepository)
	{
		this.repository = repository;
		this.mapper = mapper;
		this.accountRepository = accountRepository;
	}
	public async Task<TransactionResultDto> AddAsync(TransactionCreationDto dto)
	{
		var existSource = await accountRepository.GetAsync(c => c.Id.Equals(dto.SourceAccountId))
			?? throw new NotFoundException("SourceAccount not found");
		var existTarget = await accountRepository.GetAsync(c => c.Id.Equals(dto.TargetAccountId))
			?? throw new NotFoundException("TargetAccount not found");

		var mappedTransaction = mapper.Map<Transaction>(dto);
		mappedTransaction.SourceAccount = existSource;
		mappedTransaction.TargetAccount = existTarget;
		await repository.CreateAsync(mappedTransaction);
		await repository.SaveChanges();

		return mapper.Map<TransactionResultDto>(mappedTransaction);
	}

	public async Task<bool> DeleteAsync(long id)
	{
		var existTransaction = await repository.GetAsync(c => c.Id == id,includes: new[] { "SourceAccount", "TargetAccount" })
			?? throw new NotFoundException("This Transaction not found");

		repository.Delete(existTransaction);
		await repository.SaveChanges();

		return true;
	}

	public async Task<IEnumerable<TransactionResultDto>> GetAllAsync()
	{
		var allTransactions = await repository.GetAll(includes: new[] { "SourceAccount", "TargetAccount" }).ToListAsync();

		return mapper.Map<IEnumerable<TransactionResultDto>>(allTransactions);
	}

	public async Task<TransactionResultDto> GetAsync(long id)
	{
		var existTransaction = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Transaction not found");

		return mapper.Map<TransactionResultDto>(existTransaction);
	}

	public async Task<TransactionResultDto> UpdateAsync(TransactionUpdateDto dto)
	{
		var existTransaction = await repository.GetAsync(c => c.Id == dto.Id)
			?? throw new NotFoundException("This Transaction not found");

		mapper.Map(dto, existTransaction);
		repository.Update(existTransaction);
		await repository.SaveChanges();

		return mapper.Map<TransactionResultDto>(existTransaction);
	}
}
