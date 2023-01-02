using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Account> AccountRepository { get; }
        public WalletDbContext GetContext();
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
