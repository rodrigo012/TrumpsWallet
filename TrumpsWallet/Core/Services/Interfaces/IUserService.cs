using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Intefaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetUser(int id);
        Task<User> InsertAsync(User user);
        Task UpdateUser(int id, User user);
        Task DeleteById(int id);
    }
}