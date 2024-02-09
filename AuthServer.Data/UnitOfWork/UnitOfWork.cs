using AuthServer.Data.Context;

namespace AuthServer.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task BeginTranssections()
        {
            if (_appDbContext.Database.CurrentTransaction == null)
                await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTranssections()
        {
            if (_appDbContext.Database.CurrentTransaction != null)
                await _appDbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackTranssections()
        {
            if (_appDbContext.Database.CurrentTransaction != null)
                await _appDbContext.Database.RollbackTransactionAsync();
        }
    }
}
