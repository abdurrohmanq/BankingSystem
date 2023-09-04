using AutoMapper;
using BankingSystem.Data.IRepositories;
using BankingSystem.Domain.Entities.Accounts;
using BankingSystem.Domain.Entities.Deposits;
using BankingSystem.Service.DTOs.Deposits;
using BankingSystem.Service.Exceptions;
using BankingSystem.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Service.Services;

public class DepositService : IDepositService
{
	private readonly IRepository<Deposit> repository;
	private readonly IRepository<Account> accountRepository;
	private readonly IMapper mapper;
	public DepositService(IRepository<Deposit> repository, IMapper mapper, IRepository<Account> accountRepository)
	{
		this.repository = repository;
		this.mapper = mapper;
		this.accountRepository = accountRepository;
	}
	public async Task<DepositResultDto> AddAsync(DepositCreationDto dto)
	{
		var existCustomer = await accountRepository.GetAsync(c => c.Id.Equals(dto.AccountId))
			?? throw new NotFoundException("Account not found");

		var mappedDeposit = mapper.Map<Deposit>(dto);
		await repository.CreateAsync(mappedDeposit);
		await repository.SaveChanges();

		return mapper.Map<DepositResultDto>(mappedDeposit);
	}

	public async Task<bool> DeleteAsync(long id)
	{
		var existDeposit = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Deposit not found");

		repository.Delete(existDeposit);
		await repository.SaveChanges();

		return true;
	}

	public async Task<IEnumerable<DepositResultDto>> GetAllAsync()
	{
		var allDeposits = await repository.GetAll().ToListAsync();

		return mapper.Map<IEnumerable<DepositResultDto>>(allDeposits);
	}

	public async Task<DepositResultDto> GetAsync(long id)
	{
		var existDeposit = await repository.GetAsync(c => c.Id == id)
			?? throw new NotFoundException("This Deposit not found");

		return mapper.Map<DepositResultDto>(existDeposit);
	}

	public async Task<DepositResultDto> UpdateAsync(DepositUpdateDto dto)
	{
		var existDeposit = await repository.GetAsync(c => c.Id == dto.Id)
			?? throw new NotFoundException("This Deposit not found");

		mapper.Map(dto, existDeposit);
		repository.Update(existDeposit);
		await repository.SaveChanges();

		return mapper.Map<DepositResultDto>(existDeposit);
	}
}