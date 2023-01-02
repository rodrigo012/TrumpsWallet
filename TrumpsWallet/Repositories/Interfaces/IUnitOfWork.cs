using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Transaction> TransactionRepository { get; }
        public IGenericRepository<Role> RoleRepository { get; }
        public IGenericRepository<Account> AccountRepository { get; }
        public IGenericRepository<User> UserRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
