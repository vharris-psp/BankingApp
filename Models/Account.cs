using System.Diagnostics.CodeAnalysis;

namespace BankingApp.Models{

public class Account
    {
        public int AccountId { get; set; }
        [NotNull]
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> ?Transactions { get; set; }
        public string OwnerId { get; set; }
        public string ?CoOwnerId { get; set; }
        

        public Account()
        {
        }

        //TODO: Increment account number; 
        public string getAccountNumber()
        {
            return "000001";
        }
    }

}