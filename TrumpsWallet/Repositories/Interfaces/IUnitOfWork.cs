﻿using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Transaction> TransactionRepository { get; }
        public IGenericRepository<Role> RoleRepository { get; }
        public IGenericRepository<Account> AccountRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
