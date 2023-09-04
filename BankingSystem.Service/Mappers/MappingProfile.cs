using AutoMapper;
using BankingSystem.Domain.Entities.Accounts;
using BankingSystem.Domain.Entities.Deposits;
using BankingSystem.Domain.Entities.Loans;
using BankingSystem.Domain.Entities.Transactions;
using BankingSystem.Service.DTOs.Accounts;
using BankingSystem.Service.DTOs.Deposits;
using BankingSystem.Service.DTOs.Loans;
using BankingSystem.Service.DTOs.Transactions;

namespace BankingSystem.Service.Mappers;

public class MappingProfile : Profile
{
	public MappingProfile()
	{

		CreateMap<Account, AccountResultDto>().ReverseMap();
		CreateMap<Account, AccountCreationDto>().ReverseMap();
		CreateMap<Account, AccountUpdateDto>().ReverseMap();

		CreateMap<Deposit, DepositResultDto>().ReverseMap();
		CreateMap<Deposit, DepositCreationDto>().ReverseMap();
		CreateMap<Deposit, DepositUpdateDto>().ReverseMap();

		CreateMap<Loan, LoanResultDto>().ReverseMap();
		CreateMap<Loan, LoanCreationDto>().ReverseMap();
		CreateMap<Loan, LoanUpdateDto>().ReverseMap();

		CreateMap<Transaction, TransactionResultDto>().ReverseMap();
		CreateMap<Transaction, TransactionCreationDto>().ReverseMap();
		CreateMap<Transaction, TransactionUpdateDto>().ReverseMap();
	}
}
