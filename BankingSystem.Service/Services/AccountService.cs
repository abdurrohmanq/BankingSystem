using AutoMapper;
using BankingSystem.Data.IRepositories;
using BankingSystem.Domain.Entities.Accounts;
using BankingSystem.Service.DTOs.Accounts;
using BankingSystem.Service.DTOs.Transactions;
using BankingSystem.Service.Exceptions;
using BankingSystem.Service.Helpers;
using BankingSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Service.Services;

public class AccountService : IAccountService
{
	private readonly IRepository<Account> repository;
	private readonly ITransactionService transactionService;
	private readonly IMapper mapper;
	public AccountService(IRepository<Account> repository, IMapper mapper, ITransactionService transactionService)
	{
		this.repository = repository;
		this.mapper = mapper;
		this.transactionService = transactionService;
	}
    private string GenerateUniqueAccountNumber()
    {
        string guid = Guid.NewGuid().ToString("N");
        return "ACC" + guid;
    }
    public async Task<AccountResultDto> AddAsync(AccountCreationDto dto)
	{
		dto.AccountNumber = GenerateUniqueAccountNumber();
		var existAccount = await repository.GetAsync(c => c.AccountNumber == dto.AccountNumber);
		if (existAccount is not null)
			throw new AlreadyExistException("This Account already exist");

		var mappedAccount = mapper.Map<Account>(dto);
		mappedAccount.Password = PasswordHash.Hash(dto.Password);
		await repository.CreateAsync(mappedAccount);
		await repository.SaveChanges();

		return mapper.Map<AccountResultDto>(mappedAccount);
	}
	

	public async Task<bool> DeleteAsync(long id)
	{
		var existAccount = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Account not found");

		repository.Delete(existAccount);
		await repository.SaveChanges();

		return true;
	}

	public async Task<IEnumerable<AccountResultDto>> GetAllAsync()
	{
		var allAccounts = await repository.GetAll().ToListAsync();

		return mapper.Map<IEnumerable<AccountResultDto>>(allAccounts);
	}

	public async Task<AccountResultDto> GetAsync(long id)
	{
		var existAccount = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Account not found");

		return mapper.Map<AccountResultDto>(existAccount);
	}

	public async Task<bool> TransferFunds(long sourceAccountId, long targetAccountId, decimal amount)
{
    var existSourceAccount = await repository.GetAsync(a => a.Id == sourceAccountId)
        ?? throw new NotFoundException("Source account not found");
    var existTargetAccount = await repository.GetAsync(a => a.Id == targetAccountId)
        ?? throw new NotFoundException("Target account not found");
    
    if (existSourceAccount == existTargetAccount)
        throw new CustomException(400, "The source and target accounts cannot be the same");

    if (existSourceAccount.Balance < amount)
        throw new CustomException(401, "Insufficient funds in the source account");

    var transaction = new TransactionCreationDto
    {
        Description = $"Transfer from {existSourceAccount.FirstName} to {existTargetAccount.FirstName}",
        Amount = -amount,
        SourceAccountId = sourceAccountId,
        TargetAccountId = targetAccountId
    };

    await transactionService.AddAsync(transaction);

    existSourceAccount.Balance -= amount; // Deduct the amount from the source account
    existTargetAccount.Balance += amount; // Add the amount to the target account

    repository.Update(existSourceAccount);
    repository.Update(existTargetAccount);
    await repository.SaveChanges();

    return true;
}
	public async Task<AccountResultDto> UpdateAsync(AccountUpdateDto dto)
	{
		var existAccount = await repository.GetAsync(c => c.Id == dto.Id)
			?? throw new NotFoundException("This Account not found");

		mapper.Map(dto, existAccount);
		repository.Update(existAccount);
		await repository.SaveChanges();

		return mapper.Map<AccountResultDto>(existAccount);
	}
}