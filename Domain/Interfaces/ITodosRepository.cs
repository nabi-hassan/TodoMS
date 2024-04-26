using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITodosRepository : IRepository<Todo>
    {
        Task<Todo> GetDuplicate(Todo model);
        Task<List<Todo>> GetByListID(int? lid);
    }
}

