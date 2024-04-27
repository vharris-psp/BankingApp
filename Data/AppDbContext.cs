using Microsoft.EntityFrameworkCore;
using BankingApp.Models;

namespace BankingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet for the Account entity
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> People { get; set; } 

        // Other DbSets for other entities...

        // Configuration for your entities can go here...
    }
}
