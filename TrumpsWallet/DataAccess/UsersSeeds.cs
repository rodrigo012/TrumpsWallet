using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Entities;

namespace TrumpsWallet.DataAccess
{
    public static class UsersSeeds
    {

        public static void UsersSeed(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    FirstName = "Franco",
                    LastName = "Villarreal",
                    Email = "Franco44305@gmail.com",
                    Password = "123456789",
                    Point = 7,
                    RoleId = 1
                },
                new User()
                {

                    FirstName = "Yelfran",
                    LastName = "Giuseppe",
                    Email = "Yelfran@gmail.com",
                    Password = "Lion222",
                    Point = 5,
                    RoleId = 2
                },
                new User()
                {

                    FirstName = "Rodrigo",
                    LastName = "Roman",
                    Email = "RodrigoRoman@gmail.com",
                    Password = "LeoMessi2022",
                    Point = 4,
                    RoleId = 1
                },
                new User()
                {

                    FirstName = "Luciano",
                    LastName = "Manzanelli",
                    Email = "ManzanelliLuciano@gmail.com",
                    Password = "LM1830",
                    Point = 6,
                    RoleId = 2
                },
                new User()
                {

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
