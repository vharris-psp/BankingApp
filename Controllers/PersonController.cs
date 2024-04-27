using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BankingApp.Models;
using BankingApp.Data;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
namespace BankingApp.Controllers;
public class PersonController : Controller
{
    private readonly AppDbContext _context;

    public PersonController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var people = await _context.People.Include(p => p.Accounts).ToListAsync();
        return View (people); 
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        if (ModelState.IsValid)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(person);

    }



}
