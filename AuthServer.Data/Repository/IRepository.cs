using System.Linq.Expressions;

namespace AuthServer.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);
        Task<int> Delete(T entity);
        Task<int> Update(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(long Id);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
