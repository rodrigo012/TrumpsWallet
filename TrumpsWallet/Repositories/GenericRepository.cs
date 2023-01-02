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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly WalletDbContext context;
        private readonly DbSet<T> _entities;
        

        public GenericRepository(WalletDbContext context)
        {
            this.context = context;
            _entities = context.Set<T>();
        }
        public void Delete(int id)
        {

            var entityToDelete = _entities.Find(id);
            if (entityToDelete != null)
            {
                context.Remove(entityToDelete);
                context.SaveChanges();
            }
        }



        public async Task<List<T>> GetAll() => await this.context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();

        public async Task<T> GetById(int Id) => await (from t in this.context.Set<T>() where t.Id == Id && !t.IsDeleted select t).FirstOrDefaultAsync();

        public async Task<bool> Insert(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            try
            {
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> InsertRange(List<T> entity)
        {
            await this.context.Set<T>().AddRangeAsync(entity);
            try
            {
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                if (entity != null)
                {
                    this.context.Set<T>().Update(entity);
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
