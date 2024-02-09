using AuthServer.Data.Context;
using AuthServer.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthServer.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public Repository(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(T entity)
        {
            await _unitOfWork.BeginTranssections();
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            await _unitOfWork.BeginTranssections();
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(long Id)
        {
            return await _appDbContext.Set<T>().FindAsync(Id);

        }

        public async Task<IEnumerable<T>> IncludeAsync(params string[] properties)
        {
            IQueryable<T> query = _appDbContext.Set<T>().AsNoTracking();
            for (int i = 0; i < properties.Length; i++)
                query = query.Include(properties[i]);

            return await query.ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task Update(T entity)
        {
            await _unitOfWork.BeginTranssections();
            _appDbContext.Set<T>().Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _appDbContext.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
