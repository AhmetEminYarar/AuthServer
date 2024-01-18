using AuthServer.Data.Context;
using AuthServer.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<T>> GetAll()
        {
            return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<int> Add(T entity)
        {
            await _unitOfWork.BeginTranssections();
            await _appDbContext.Set<T>().AddAsync(entity);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            await _unitOfWork.BeginTranssections();
            _appDbContext.Set<T>().Remove(entity);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            await _unitOfWork.BeginTranssections();
            _appDbContext.Set<T>().Update(entity);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(int Id)
        {

            return await _appDbContext.Set<T>().FindAsync(Id);
        }
    }
}
