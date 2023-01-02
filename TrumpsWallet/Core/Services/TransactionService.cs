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
        public async Task<List<Transaction>> GetAll()
        {
            return await unitOfWork.TransactionRepository.GetAll();
        }
        public async Task<Transaction> GetTransaction(int id)
        {
            return await unitOfWork.TransactionRepository.GetById(id);
        }
        public async Task<Transaction> InsertAsync(Transaction transaction)
        {
            Transaction newtransaction = new Transaction();
            newtransaction.Amount = transaction.Amount;
            newtransaction.Concept = transaction.Concept;
            newtransaction.Date = transaction.Date;
            newtransaction.Type = transaction.Type;
            
            await unitOfWork.TransactionRepository.Insert(newtransaction);
            await unitOfWork.SaveChangesAsync();
            return transaction;
        }
        public async Task UpdateTransaction(int id, Transaction transaction)
        {
            if (transaction.Id == id)
            {
                unitOfWork.TransactionRepository.Update(transaction);
                await unitOfWork.SaveChangesAsync();
            }
        }
        public async Task DeleteById(int id)
        {
            var TransactionDelete = await unitOfWork.TransactionRepository.GetById(id);

            if(TransactionDelete != null)
            {
                  unitOfWork.TransactionRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
 