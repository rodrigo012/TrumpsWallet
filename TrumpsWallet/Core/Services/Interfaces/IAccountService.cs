using TrumpsWallet.Core.Models;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDto> Insert(AccountDto account);
        Task<List<AccountDto>> GetAllAccountAsync();
        Task<AccountDto> GetAccountAsync(int id);
        Task DeleteAccountAsync(int id);
        Task UpdateAccountAsync(AccountDto editAccount);
    }
}
