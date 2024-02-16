using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public ITodoGroupsRepository TodoGroupsRepository { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            TodoGroupsRepository = new TodoGroupsRepository(_appDbContext);
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public Task<int> SaveChanges()
        {
            return _appDbContext.SaveChangesAsync();
        }
    }
}
