using Applicaton.Dtos;
using Applicaton.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface ITodoListsService : IGenericService<TodoListDTO>
    {
        Task<ApiResponse> GetByGroupID(int? gid);
    }
}
