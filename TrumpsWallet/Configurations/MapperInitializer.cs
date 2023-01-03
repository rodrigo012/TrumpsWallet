﻿using AutoMapper;
using TrumpsWallet.Core.Models;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Configurations
{
    public class MapperInitializer : Profile
    {

        public MapperInitializer()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
        }

    }
}
