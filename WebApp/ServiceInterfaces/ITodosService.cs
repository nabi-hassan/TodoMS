using Applicaton.Dtos;
using Applicaton.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface ITodosService : IGenericService<TodoDTO>
    {
        Task<ApiResponse> GetByListID(int? lid);

    }
}
