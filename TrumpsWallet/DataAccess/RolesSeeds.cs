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
                     Id= 1,
                     Name = "Admin",
                     Description = "Usuario Administrador",
                 },
                new Role()
                {
                    Id = 2,
                    Name = "Cliente",
                    Description = "Usuario Cliente",
                });
        }
    }
}
