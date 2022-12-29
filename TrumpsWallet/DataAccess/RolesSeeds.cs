using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Entities;

namespace TrumpsWallet.DataAccess
{
    public static class RolesSeeds
    {
        public static void RolesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                 new Role()
                 {

                     Name = "Admin",
                     Description = "Usuario Administrador",
                 },
                new Role()
                {

                    Name = "Cliente",
                    Description = "Usuario Cliente",
                });
        }
    }
}
