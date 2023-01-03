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
            modelBuilder.RoleDataSeed();
            modelBuilder.UserDataSeed();
            modelBuilder.AccountDataSeed();
            modelBuilder.TransactionDataSeed();
        }
 
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<Account> Accounts { get; set; }
        public  DbSet<Role> Roles { get; set; }
    }
}
