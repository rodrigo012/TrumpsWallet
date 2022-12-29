using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrumpsWallet.Entities;

namespace TrumpsWallet.DataAccess
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedDataRole(modelBuilder);
            this.SeedDataAccounts(modelBuilder);
            this.SeedDataTransactions(modelBuilder);

        }

        private void SeedDataRole(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Usuario Administrador",
                },
                new Role()
                {
                    Id = 2,
                    Name = "Cliente",
                    Description = "Usuario Cliente",
                });
        }

        private void SeedDataAccounts(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(
                new Account()
                {
                    Id = 1,
                    creationDate = DateTime.Now,
                    money = 81000,
                    isBlocked = false,
                    userId = 1
                },
                new Account()
                {
                    Id = 2,
                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 2
                },
                new Account()
                {
                    Id = 3,
                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 3
                },
                new Account()
                {
                    Id = 4,
                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 4
                },
                new Account()
                {
                    Id = 5,
                    creationDate = DateTime.Now,
                    money = 15000,
                    isBlocked = false,
                    userId = 5
                });

        }
        private void SeedDataTransactions(ModelBuilder builder)
        {
            builder.Entity<Transaction>().HasData(
                new Transaction()
                {
                    Id = 1,
                    UserID = 1,
                    AccountID = 1,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 2,

                },
                new Transaction()
                {
                    Id = 2,
                    UserID = 2,
                    AccountID = 2,
                    Date = DateTime.Now,
                    Amount = 200,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 5,

                },
                new Transaction()
                {
                    Id = 3,
                    UserID = 3,
                    AccountID = 3,
                    Date = DateTime.Now,
                    Amount = 150,
                    Concept = "Recarga",
                    Type = "Topup",
                    toAccountID = 2,

                },
                new Transaction()
                {
                    Id = 4,
                    UserID = 4,
                    AccountID = 4,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 1,

                },
                new Transaction()
                {
                    Id = 5,
                    UserID = 5,
                    AccountID = 5,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Recarga",
                    Type = "Topup",
                    toAccountID = 3,

                });

        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}
