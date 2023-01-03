using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Transaction>> GetAllTransactionsAsync()
        {
            var result = await unitOfWork.TransactionRepository.GetAll();
            return result;
        }
        public async Task<Transaction> GetTransactionAsync(int id)
        {
            var result = await unitOfWork.TransactionRepository.GetById(id);
            return result;
        }
        public async Task<Transaction> Insert(Transaction transactionEntity)
        {
            await unitOfWork.TransactionRepository.Insert(transactionEntity);
            await unitOfWork.SaveChangesAsync();
            return transactionEntity;
        }
        public async Task UpdateTransactionAsync(Transaction editTransaction)
        {
            await unitOfWork.TransactionRepository.Update(editTransaction);
            unitOfWork.SaveChanges();
        }
        public async Task DeleteTransactionAsync(int id)
        {
            await unitOfWork.TransactionRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();

        }
    }
}
 