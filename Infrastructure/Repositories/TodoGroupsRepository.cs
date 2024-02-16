using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoGroupsRepository : Repository<TodoGroup>, ITodoGroupsRepository
    {
        public TodoGroupsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<TodoGroup> GetDuplicate(TodoGroup model)
        {
            return _appDbContext.TodoGroups.FirstOrDefaultAsync(x => x.GroupName.ToLower() == model.GroupName.ToLower());
        }
    }
}
