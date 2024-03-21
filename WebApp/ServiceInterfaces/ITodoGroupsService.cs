using Applicaton.Dtos;
using Applicaton.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface ITodoGroupsService
    {
        Task<ApiResponse> Get();
        /*Task<ApiResponse> Get(int id);
        Task<ApiResponse> Create(TodoGroupDTO modelDto);
        Task<ApiResponse> Edit(int id, TodoGroupDTO modelDto);
        Task<ApiResponse> Delete(int id);*/
    }
}
