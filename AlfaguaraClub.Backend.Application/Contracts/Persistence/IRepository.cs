﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);

        Task<IList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        IQueryable<T> Query();

        IQueryable<T> QueryNoTracking();
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    }
}
