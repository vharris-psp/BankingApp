using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BankingApp.Models;
using BankingApp.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
namespace BankingApp.Controllers;
public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }


    public IActionResult Create()
    {
        var viewModel = new AccountCreateViewModel
        {
            People = _context.People.Select(p => new SelectListItem
            {
               Value = p.PersonId.ToString(),
               Text = $"{p.FirstName} {p.LastName}"
            }).ToList()
        };

        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AccountCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            

            var account = new Account()
            {
                AccountNumber = GetNextAccountNumber(),
                OwnerId = viewModel.OwnerId.ToString(),
                CoOwnerId = viewModel.CoOwnerId.ToString(),
                Balance = viewModel.Balance
            };
            
            _context.Add(account);
            await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index));
        }
        
        return View(viewModel); 
    }
    public IActionResult Index()
    {
        Console.WriteLine("Account Index");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("AccountNumber,Balance")] Account account, AccountCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        viewModel.People = _context.People.Select(p => new SelectListItem
        {
            Value = p.PersonId.ToString(),
            Text = $"{p.FirstName} {p.LastName}",
        }).ToList();
        return View(account);
    }

    public string GetNextAccountNumber()
    {
        var lastAccount = _context.Accounts.OrderByDescending(a => a.AccountNumber).FirstOrDefault();
        if (lastAccount == null)
        {
            return "000001";
        }
        else{
            int currentNumber = int.Parse(lastAccount.AccountNumber);
            currentNumber++;
            return currentNumber.ToString("D6");
        }
    } 
    
}
