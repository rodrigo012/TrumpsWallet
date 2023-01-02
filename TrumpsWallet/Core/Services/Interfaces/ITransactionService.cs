using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAll();
        Task<Transaction> GetTransaction(int id);
        Task<Transaction> InsertAsync(Transaction transaction);
        Task UpdateTransaction(int id,Transaction transaction);
        Task DeleteById(int id);
    }
}
