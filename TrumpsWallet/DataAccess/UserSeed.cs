using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Entities;

namespace TrumpsWallet.DataAccess
{
    public static class UserSeed
    {

        public static void UserDataSeed(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Franco",
                    LastName = "Villarreal",
                    Email = "Franco44305@gmail.com",
                    Password = "123456789",
                    Point = 7,
                    RoleId = 1
                },
                new User()
                {
                    Id=2,
                    FirstName = "Yelfran",
                    LastName = "Giuseppe",
                    Email = "Yelfran@gmail.com",
                    Password = "Lion222",
                    Point = 5,
                    RoleId = 2
                },
                new User()
                {
                    Id=3,
                    FirstName = "Rodrigo",
                    LastName = "Roman",
                    Email = "RodrigoRoman@gmail.com",
                    Password = "LeoMessi2022",
                    Point = 4,
                    RoleId = 1
                },
                new User()
                {
                    Id=4,
                    FirstName = "Luciano",
                    LastName = "Manzanelli",
                    Email = "ManzanelliLuciano@gmail.com",
                    Password = "LM1830",
                    Point = 6,
                    RoleId = 2
                },
                new User()
                {
                    Id=5,
                    FirstName = "Daniel",
                    LastName = "Depablos",
                    Email = "DaniDepablos@gmail.com",
                    Password = "Mango207",
                    Point = 3,
                    RoleId = 1
                });
        }
    }
}
