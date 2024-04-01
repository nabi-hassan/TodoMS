using Applicaton.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface IGenericService<TDto> where TDto : class
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(int id);
        Task<ApiResponse> Create(TDto modelDto);
        Task<ApiResponse> Edit(int id, TDto modelDto);
        Task<ApiResponse> Delete(int id);
    }
}
