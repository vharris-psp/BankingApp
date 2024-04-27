using System.Collections.Generic;
using BankingApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Models
{
    public class AccountCreateViewModel
    {
        private readonly AppDbContext _context; // Declare _context as a private field
        public string ?AccountNumber { get; set; }
        public int OwnerId { get; set; }
        public int CoOwnerId { get; set; }
        public decimal Balance { get; set; }

        public List<SelectListItem> People { get; set; }
        
    } 
        
}
