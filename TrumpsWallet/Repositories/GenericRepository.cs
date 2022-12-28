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
        private readonly WalletDbContext _context;

        public GenericRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.LastModified = DateTime.Now;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<T>> GetAll() => await _context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();

        public async Task<T> GetById(int Id) => await (from t in _context.Set<T>() where t.Id == Id && !t.IsDeleted select t).FirstOrDefaultAsync();

        public async Task<bool> Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> InsertRange(List<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            try
            {
                await _context.SaveChangesAsync();
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
                    _context.Set<T>().Update(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetAsync(QueryProperty<T> query)
        {
            try
            {
                var source = ApplyQuery(query, _context.Set<T>().AsQueryable().Where(x => !x.IsDeleted));
                return await source.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<int> CountElements() => await _context.Set<T>().CountAsync();

        private static IQueryable<T> ApplyQuery(QueryProperty<T> query, IQueryable<T> source)
        {
            if (query is null)
                return source;

            if (query.Where is not null)
                source = source.Where(query.Where);

            foreach (var property in query.Includes)
                source = source.Include(property);

            if (query.Skip > 0)
                source = source.Skip(query.Skip);

            if (query.Take > 0)
                source = source.Take(query.Take);

            return source;
        }
    }
}
