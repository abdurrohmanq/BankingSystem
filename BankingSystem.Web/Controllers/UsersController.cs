using AutoMapper;
using BankingSystem.Domain.Entities.Accounts;
using BankingSystem.Service.DTOs.Accounts;
using BankingSystem.Service.Interfaces;
using BankingSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BankingSystem.Web.Controllers;

public class UsersController : Controller
{
	private readonly IAccountService _accountService;
	private readonly IMapper mapper;
    public UsersController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        this.mapper = mapper;
    }

    public IActionResult Create()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Create(AccountCreationDto dto)
	{
		var createdAccount = await _accountService.AddAsync(dto);
		return RedirectToAction("Index");
	}

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var user = await _accountService.GetAsync(id);
        var mappedUser = mapper.Map<Account>(user);
        return View(mappedUser);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Account model)
    {
        var mappedUser = mapper.Map<AccountUpdateDto>(model);
        var user = await _accountService.UpdateAsync(mappedUser);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Detail(long id)
    {
        var account = await _accountService.GetAsync(id);
        var mappedAccount = mapper.Map<Account>(account);
        return View(mappedAccount);
    }

    public IActionResult Transfer()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Transfer(long checkout, long transferTo,decimal amount)
    {
        var sourceId = checkout; 
        var targetId = transferTo;
        var transfer = await _accountService.TransferFunds(sourceId, targetId, amount);
        return RedirectToAction("Index", "Transactions");
    }
    public async Task<IActionResult> Index()
	{
		var accounts = await _accountService.GetAllAsync();
		return View(accounts);
	}
}