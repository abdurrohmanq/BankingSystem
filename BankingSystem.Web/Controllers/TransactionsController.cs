using BankingSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Web.Controllers;

public class TransactionsController : Controller
{
    private readonly ITransactionService _transactionService;
    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    public async Task<IActionResult> Index()
    {
        var transactions = await _transactionService.GetAllAsync(); 
        return View(transactions);
    }
}
