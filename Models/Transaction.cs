// Models/Transaction.cs
using System;

namespace BankingApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; } // For simplicity, "Credit" or "Debit"
        public Account Account { get; set; }
    }
}
