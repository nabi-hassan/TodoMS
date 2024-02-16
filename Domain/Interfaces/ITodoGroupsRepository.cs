using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITodoGroupsRepository : IRepository<TodoGroup>
    {
        Task<TodoGroup> GetDuplicate(TodoGroup model);
    }
}
