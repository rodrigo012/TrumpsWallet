using TrumpsWallet.DataAccess;
using TrumpsWallet.Repositories.Interfaces;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletDbContext context;
        private readonly IGenericRepository<Account> accountRepository;

        public UnitOfWork(WalletDbContext context)
        {
            this.context = context;
        }

        public WalletDbContext GetContext()
        {
            return context;
        }

        public IGenericRepository<Account> AccountRepository => accountRepository ?? new AccountRepository<Account>(this.context);

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
