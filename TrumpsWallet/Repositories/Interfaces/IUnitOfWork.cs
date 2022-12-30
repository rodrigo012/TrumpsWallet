using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Transaction> TransactionRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
