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
        public async Task<List<User>> GetAll()
        {
            return await unitOfWork.UserRepository.GetAll();
        }
        public async Task<User> GetUser(int id)
        {
            return await unitOfWork.UserRepository.GetById(id);
        }
        public async Task<User> InsertAsync(User user)
        {
            //User newuser= new User();
            //newuser.FirstName = user.FirstName;
            //newuser.LastName = user.LastName;
            //newuser.Email = user.Email;
            //newuser.Password = user.Password;
            //newuser.Point = user.Point;

            await unitOfWork.UserRepository.Insert(user);
            await unitOfWork.SaveChangesAsync();
            return user;
        }
        public async Task UpdateUser(int id, User user)
        {
            if (user.Id == id)
            {
                unitOfWork.UserRepository.Update(user);
                await unitOfWork.SaveChangesAsync();
            }
        }
        public async Task DeleteById(int id)
        {
            var UserDelete = await unitOfWork.UserRepository.GetById(id);

            if(UserDelete != null)
            {
                  unitOfWork.UserRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
 