using Microsoft.EntityFrameworkCore;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories.Interfaces;


namespace TrumpsWallet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletDbContext context;
        private readonly IGenericRepository<Account> accountRepository;
        private readonly IGenericRepository<Transaction> _transactionRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<User> _userRepository;

        public UnitOfWork(WalletDbContext context)
        {
            this.context = context;
        }

        public WalletDbContext GetContext()
        {
            return context;
        }

        

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public IGenericRepository<Transaction> TransactionRepository => _transactionRepository ?? new GenericRepository<Transaction>(context);
        public IGenericRepository<Role> RoleRepository => _roleRepository ?? new GenericRepository<Role>(context);
        public IGenericRepository<User> UserRepository => _userRepository ?? new GenericRepository<User>(context);
        public IGenericRepository<Account> AccountRepository => accountRepository ?? new GenericRepository<Account>(context);

    }
}

