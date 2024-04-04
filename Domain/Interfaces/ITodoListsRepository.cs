using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITodoListsRepository : IRepository<TodoList>
    {
        Task<TodoList> GetDuplicate(TodoList model);
        Task<List<TodoList>> GetByGroupID(int? gid);
    }
}

