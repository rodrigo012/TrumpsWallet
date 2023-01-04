using TrumpsWallet.Core.Services.Intefaces;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<User>> GetAllUserAsync()
        {
            var result = await unitOfWork.UserRepository.GetAll();
            return result;
        }
        public async Task<User> GetUserAsync(int id)
        {
            var result = await unitOfWork.UserRepository.GetById(id);
            return result;
        }

        public async Task<User> Insert(User userEntity)
        {
            await unitOfWork.UserRepository.Insert(userEntity);
            await unitOfWork.SaveChangesAsync();
            return userEntity;
        }

        public async Task DeleteUserAsync(int id)
        {
            await unitOfWork.UserRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();
        }


        public async Task UpdateUserAsync(User editUser)
        {
            await unitOfWork.UserRepository.Update(editUser);
            unitOfWork.SaveChanges();
        }
    }
}
