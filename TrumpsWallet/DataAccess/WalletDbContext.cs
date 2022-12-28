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
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }
}
