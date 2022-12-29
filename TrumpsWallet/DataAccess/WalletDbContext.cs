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
            this.SeedDataAccounts(modelBuilder);
        
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
                    money = 1500,
                    isBlocked = false,
                    userId = 3
                });
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}
