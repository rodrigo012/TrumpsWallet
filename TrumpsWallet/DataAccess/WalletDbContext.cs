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

        private void SeedDataUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    FirstName = "Franco",
                    LastName = "Villarreal",
                    Email = "Franco44305@gmail.com",
                    Password = "123456789",
                    Point = 7,
                    RoleId = 1
                },
                new User()
                {
                    
                    FirstName = "Yelfran",
                    LastName = "Giuseppe",
                    Email = "Yelfran@gmail.com",
                    Password = "Lion222",
                    Point = 5,
                    RoleId = 2
                },
                new User()
                {
                    
                    FirstName = "Rodrigo",
                    LastName = "Roman",
                    Email = "RodrigoRoman@gmail.com",
                    Password = "LeoMessi2022",
                    Point = 4,
                    RoleId = 1
                },
                new User()
                {
                    
                    FirstName = "Luciano",
                    LastName = "Manzanelli",
                    Email = "ManzanelliLuciano@gmail.com",
                    Password = "LM1830",
                    Point = 6,
                    RoleId = 2
                },
                new User()
                {
                    
                    FirstName = "Daniel",
                    LastName = "Depablos",
                    Email = "DaniDepablos@gmail.com",
                    Password = "Mango207",
                    Point = 3,
                    RoleId = 1
                });
        }
        private void SeedDataRole(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role()
                {
                   
                    Name = "Admin",
                    Description = "Usuario Administrador",
                },
                new Role()
                {
                   
                    Name = "Cliente",
                    Description = "Usuario Cliente",
                });
        }

        private void SeedDataAccounts(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(
                new Account()
                {
                   
                    creationDate = DateTime.Now,
                    money = 81000,
                    isBlocked = false,
                    userId = 1
                },
                new Account()
                {
                    
                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 2
                },
                new Account()
                {
                    
                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 3
                },
                new Account()
                {
                   
                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 4
                },
                new Account()
                {
                    
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
                    
                    UserID = 1,
                    AccountID = 1,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 10,

                },
                new Transaction()
                {
                   
                    UserID = 2,
                    AccountID = 2,
                    Date = DateTime.Now,
                    Amount = 200,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 3,

                },
                new Transaction()
                {
                    
                    UserID = 1,
                    AccountID = 1,
                    Date = DateTime.Now,
                    Amount = 150,
                    Concept = "Recarga",
                    Type = "Topup"

                },
                new Transaction()
                {
                    
                    UserID = 3,
                    AccountID = 3,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 1,

                },
                new Transaction()
                {
                   
                    UserID = 4,
                    AccountID = 4,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Recarga",
                    Type = "Topup"

                });
        }
 
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}
