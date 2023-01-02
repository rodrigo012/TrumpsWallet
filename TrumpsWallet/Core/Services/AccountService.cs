using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Core.Models;
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
        public async Task<AccountDto> Insert(AccountDto account)
        {
            Account accountEntity = new Account();

            accountEntity.money = account.money;
            accountEntity.creationDate = account.creationDate;
            accountEntity.isBlocked = false;
            accountEntity.userId = account.userId;

            await unitOfWork.AccountRepository.Insert(accountEntity);
            await unitOfWork.SaveChangesAsync();
            return account;
        }

        public async Task<List<AccountDto>> GetAllAccountAsync()
        {
            List<AccountDto> accountDtoList = new List<AccountDto>();
            AccountDto accountDto = new AccountDto();

            var result = await unitOfWork.AccountRepository.GetAll();
            foreach (var accountList in result)
            {
                accountDto.money = accountList.money;
                accountDto.creationDate = accountList.creationDate;
                accountDto.isBlocked = accountList.isBlocked;
                accountDto.userId = accountList.userId;
                accountDtoList.Add(accountDto);
            }
            return accountDtoList;
        }

        public async Task<AccountDto> GetAccountAsync(int id)
        {
            AccountDto accountDto = new AccountDto();

            var result = await unitOfWork.AccountRepository.GetById(id);
            accountDto.creationDate = result.creationDate;
            accountDto.money = result.money;
            accountDto.isBlocked = result.isBlocked;
            accountDto.userId = result.userId;
            return accountDto;
        }

        public async Task DeleteAccountAsync(int id)
        {
            await unitOfWork.AccountRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(AccountDto editAccount)
        {
            Account accountEntity = new Account();

            accountEntity.money = editAccount.money;
            accountEntity.creationDate = editAccount.creationDate;
            accountEntity.isBlocked = editAccount.isBlocked;
            accountEntity.userId = editAccount.userId;
            await unitOfWork.AccountRepository.Update(accountEntity);
            unitOfWork.SaveChanges();
        }

    }
}
