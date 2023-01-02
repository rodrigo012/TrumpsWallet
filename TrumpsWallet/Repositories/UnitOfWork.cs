using Microsoft.EntityFrameworkCore;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories.Interfaces;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletDbContext _context;
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IGenericRepository<Role> _roleRepository;

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
        public IGenericRepository<Transaction> TransactionRepository => _transactionRepository ?? new GenericRepository<Transaction>(_context);
        public IGenericRepository<Role> RoleRepository => _roleRepository ?? new GenericRepository<Role>(_context);

        public void SaveChanges() =>_context.SaveChanges();

        public async Task SaveChangesAsync() =>await _context.SaveChangesAsync();
    }
}

