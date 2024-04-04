using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodoListsRepository : Repository<TodoList>, ITodoListsRepository
    {
        public TodoListsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<TodoList> GetDuplicate(TodoList model)
        {
            return _appDbContext.TodoLists.FirstOrDefaultAsync(x => x.ListName.ToLower() == model.ListName.ToLower());
        }

        public Task<List<TodoList>> GetByGroupID(int? gid)
        {
            return _appDbContext.TodoLists.Where(x => x.TodoGroupId == gid).ToListAsync();
        }
    }
}
