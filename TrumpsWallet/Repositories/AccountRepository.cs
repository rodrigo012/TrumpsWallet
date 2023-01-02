using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Entities;
using TrumpsWallet.Repositories.Interfaces;

namespace TrumpsWallet.Repositories
{
    public class AccountRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly WalletDbContext context;
        protected readonly DbSet<T> entities;

        public AccountRepository(WalletDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity != null)
            {
                context.Remove(entity);
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAll() => await this.context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();

        public async Task<T> GetById(int Id) => await (from t in this.context.Set<T>() where t.Id == Id && !t.IsDeleted select t).FirstOrDefaultAsync();

        public async Task<bool> Insert(T entity)
        {
            
            try
            {
                await entities.AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> InsertRange(List<T> entity)
        {
            
            try
            {
                await entities.AddRangeAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(T entityUpdate)
        {
            try
            {
                if (entityUpdate != null)
                {
                    var entity = await context.Accounts.FindAsync(entityUpdate.Id);

                    if (entity is null)
                    {
                        throw new NullReferenceException("La cuenta no existe");
                    }
                    context.Set<T>().Update(entityUpdate);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
