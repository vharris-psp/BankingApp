using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace BankingApp.Models{

public class Person
    {
        public int PersonId { get; set; }
        [NotNull]
        public string Name { get { return $"{LastName}, {FirstName}"; } } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        
        public decimal InvestmentsTotal { get { return InvestmentSum(); } }
        public List<Account> ?Accounts { get; set; }

        public Person()
        {
            
        }       
        private decimal InvestmentSum()
        {
            decimal sum = 0; 
            foreach (Account account in Accounts)
            {
                sum += account.Balance;
            }
            return sum; 
        }
    }

}