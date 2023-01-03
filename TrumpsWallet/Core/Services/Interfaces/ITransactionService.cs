using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransactionsAsync();
        Task<Transaction> GetTransactionAsync(int id);
        Task<Transaction> Insert(Transaction transactionEntity);
        Task UpdateTransactionAsync(Transaction editTransaction);
        Task DeleteTransactionAsync(int id);
    }
}
