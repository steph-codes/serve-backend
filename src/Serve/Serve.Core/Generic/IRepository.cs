using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Core.Generic
{
    public interface IRepository<T> where T : class
    {
        //IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        int Count();
        Task<int> CountAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        T Get(int id);
        T Get(long id);
        T Get(short id);
        T Get(decimal id);
        T Get(string id);
        IEnumerable<T> GetAll();
        Task<ICollection<T>> GetAllAsyn();
        Task<T> GetAsync(int id);
        Task<T> GetAsync(long id);
        Task<T> GetAsync(short id);
        Task<T> GetAsync(decimal id);
        Task<T> GetAsync(string id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
