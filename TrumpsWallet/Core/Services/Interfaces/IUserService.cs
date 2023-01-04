using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Intefaces
{
    public interface IUserService
    {
        Task<User> Insert(User userEntity);
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserAsync(int id);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(User editUser);
    }
}