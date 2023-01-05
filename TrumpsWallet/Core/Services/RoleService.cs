using Microsoft.EntityFrameworkCore;
using System.Data;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Core.Services
{
    public class RoleService : IRoleService
    {

        private readonly IUnitOfWork unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Role>> GetAllRoles()
        {
            return await unitOfWork.RoleRepository.GetAll();
        }

        public async Task<Role> GetById(int id)
        {
            return await unitOfWork.RoleRepository.GetById(id);
        }

        public async Task<Role> InsertAsync(Role role)
        {
            Role newrole = new Role();
            newrole.Name = role.Name;
            newrole.Description = role.Description;

            await unitOfWork.RoleRepository.Insert(newrole);
            await unitOfWork.SaveChangesAsync();
            return role;
        }

        public async Task UpdateRole(int id, Role role)
        {
            if (role.Id == id)
            {
                await unitOfWork.RoleRepository.Update(role);
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            var RoleDelete = await unitOfWork.RoleRepository.GetById(id);

            if (RoleDelete != null)
            {
                await unitOfWork.RoleRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
            }
        }

    }
}
