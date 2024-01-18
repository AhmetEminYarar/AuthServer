namespace AuthServer.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginTranssections();
        Task CommitTranssections();
        Task RollbackTranssections();
    }
}
