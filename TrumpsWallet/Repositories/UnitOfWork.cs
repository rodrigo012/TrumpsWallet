using Microsoft.EntityFrameworkCore;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletDbContext _context;
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IGenericRepository<Role> _roleRepository;

        public UnitOfWork(WalletDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Transaction> TransactionRepository => _transactionRepository ?? new GenericRepository<Transaction>(_context);
        public IGenericRepository<Role> RoleRepository => _roleRepository ?? new GenericRepository<Role>(_context);

        public void SaveChanges() =>_context.SaveChanges();

        public async Task SaveChangesAsync() =>await _context.SaveChangesAsync();
    }
}

