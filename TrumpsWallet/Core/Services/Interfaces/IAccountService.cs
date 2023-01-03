using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> Insert(Account accountEntity);
        Task<List<Account>> GetAllAccountAsync();
        Task<Account> GetAccountAsync(int id);
        Task DeleteAccountAsync(int id);
        Task UpdateAccountAsync(Account editAccount);
    }
}
