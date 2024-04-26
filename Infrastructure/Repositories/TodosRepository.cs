using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TodosRepository : Repository<Todo>, ITodosRepository
    {
        public TodosRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<Todo> GetDuplicate(Todo model)
        {
            return _appDbContext.Todos.FirstOrDefaultAsync(x => x.TodoItem.ToLower() == model.TodoItem.ToLower());
        }

        public Task<List<Todo>> GetByListID(int? lid)
        {
            return _appDbContext.Todos.Where(x => x.TodoListId == lid).ToListAsync();
        }
    }
}
