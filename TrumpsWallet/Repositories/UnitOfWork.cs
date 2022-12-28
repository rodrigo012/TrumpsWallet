using TrumpsWallet.DataAccess;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletDbContext _context;

        public UnitOfWork(WalletDbContext context)
        {
            _context = context;
        }
    }
}
