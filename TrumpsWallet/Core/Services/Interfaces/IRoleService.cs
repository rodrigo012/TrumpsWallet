using TrumpsWallet.Entities;

namespace TrumpsWallet.Core.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();

        Task<Role> GetById(int id);
        Task<Role> InsertAsync(Role role);
        Task UpdateRole(int id, Role role);
        Task DeleteById(int id);
    }
}
