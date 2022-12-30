﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TrumpsWallet.Entities;

namespace TrumpsWallet.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<bool> Insert(T entity);
        Task<bool> InsertRange(List<T> entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        void Delete(T entity);
        Task<bool> Update(T entity);
        Task<List<T>> GetAsync(QueryProperty<T> query);
        Task<int> CountElements();
    }
}
