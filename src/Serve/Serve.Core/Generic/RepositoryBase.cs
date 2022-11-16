using Serve.Core.Models;
using Serve.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using t = System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Serve.Core.Generic
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly ServeDbContext Context;

        public RepositoryBase(ServeDbContext context)
        {
            Context = context;
            // AS of date EFCORE does not support lazy loading. 12-3-2018
        }

        //public IQueryable<T> FindAll(bool trackChanges) => 
        //    !trackChanges ? Context.Set<T>().AsNoTracking() : Context.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) => !trackChanges ? Context.Set<T>().Where(expression).AsNoTracking()
            : Context.Set<T>().Where(expression);
        public void Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async t.Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public async t.Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public int Count()
        {
            return Context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        public T Get(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Get(short id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Get(decimal id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Get(string id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(long id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(short id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(decimal id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(string id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsyn()
        {

            return await Context.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }


        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Context.Set<T>().UpdateRange(entities);
        }
    }
}
