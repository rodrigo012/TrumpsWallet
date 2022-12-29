﻿using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Entities;

namespace TrumpsWallet.DataAccess
{
    public static class AccountsSeeds
    {
        public static void AccountsSeed(this ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(
                new Account()
                {

                    creationDate = DateTime.Now,
                    money = 81000,
                    isBlocked = false,
                    userId = 1
                },
                new Account()
                {

                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 2
                },
                new Account()
                {

                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 3
                },
                new Account()
                {

                    creationDate = DateTime.Now,
                    money = 30000,
                    isBlocked = true,
                    userId = 4
                },
                new Account()
                {

                    creationDate = DateTime.Now,
                    money = 15000,
                    isBlocked = false,
                    userId = 5
                });

        }
    }
}