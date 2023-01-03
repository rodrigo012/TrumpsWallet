using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Account> Insert(Account accountEntity)
        {
            await unitOfWork.AccountRepository.Insert(accountEntity);
            await unitOfWork.SaveChangesAsync();
            return accountEntity;
        }

        public async Task<List<Account>> GetAllAccountAsync()
        {
            var result = await unitOfWork.AccountRepository.GetAll();
            return result;
        }

        public async Task<Account> GetAccountAsync(int id)
        {
            var result = await unitOfWork.AccountRepository.GetById(id);
            return result;
        }

        public async Task DeleteAccountAsync(int id)
        {
            await unitOfWork.AccountRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account editAccount)
        {
            await unitOfWork.AccountRepository.Update(editAccount);
            unitOfWork.SaveChanges();
        }

    }
}
