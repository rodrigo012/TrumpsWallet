using TrumpsWallet.Core.Services.Intefaces;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories;

namespace TrumpsWallet.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly UnitOfWork _unitOfWork;
        public TransactionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Transaction>> GetAll()
        {
            return await _unitOfWork.TransactionRepository.GetAll();
        }
        public async Task<Transaction> GetTransaction(int id)
        {
            return await _unitOfWork.TransactionRepository.GetById(id);
        }
        public async Task<Transaction> InsertAsync(Transaction transaction)
        {
            Transaction newtransaction = new Transaction();
            newtransaction.userId = transaction.userId;
            newtransaction.AccountID = transaction.AccountID;
            newtransaction.Amount = transaction.Amount;
            newtransaction.Concept = transaction.Concept;
            newtransaction.Date = transaction.Date;
            newtransaction.Type = transaction.Type;
            
            await _unitOfWork.TransactionRepository.Insert(newtransaction);
            await _unitOfWork.SaveChangesAsync();
            return transaction;
        }
        public async Task UpdateTransaction(int id, Transaction transaction)
        {
            if (transaction.Id == id)
            {
                _unitOfWork.TransactionRepository.Update(transaction);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task DeleteById(int id)
        {
            var TransactionDelete = await _unitOfWork.TransactionRepository.GetById(id);

            if(TransactionDelete != null)
            {
                  _unitOfWork.TransactionRepository.Delete(TransactionDelete);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
