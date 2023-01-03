using AutoMapper;
using TrumpsWallet.Core.DTOs;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Configurations
{
    public class MapperInitializer : Profile
    {

        public MapperInitializer()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();
        }

    }
}
