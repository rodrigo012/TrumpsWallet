using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Entities;

namespace TrumpsWallet.DataAccess
{
    public static class TransactionSeed
    {
        public static void TransactionDataSeed(this ModelBuilder builder)
        {
            builder.Entity<Transaction>().HasData(
                new Transaction()
                {
                    Id = 1,
                    UserID = 1,
                    AccountID = 1,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 10,

                },
                new Transaction()
                {
                    Id=2,
                    UserID = 2,
                    AccountID = 2,
                    Date = DateTime.Now,
                    Amount = 200,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 3,

                },
                new Transaction()
                {
                    Id=3,
                    UserID = 1,
                    AccountID = 1,
                    Date = DateTime.Now,
                    Amount = 150,
                    Concept = "Recarga",
                    Type = "Topup"

                },
                new Transaction()
                {
                    Id=4,
                    UserID = 3,
                    AccountID = 3,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Transferencia",
                    Type = "Payment",
                    toAccountID = 1,

                },
                new Transaction()
                {
                    Id=5,
                    UserID = 4,
                    AccountID = 4,
                    Date = DateTime.Now,
                    Amount = 2000,
                    Concept = "Recarga",
                    Type = "Topup"

                });
        }
    }
}
