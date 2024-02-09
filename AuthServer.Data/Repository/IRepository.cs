using System.Linq.Expressions;

namespace AuthServer.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long Id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);        
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> IncludeAsync(params string[] properties);
    }
}
