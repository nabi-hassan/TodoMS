using Applicaton.Dtos;
using Applicaton.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class GenericService<TDto> : IGenericService<TDto> where TDto : class
    {
        private readonly IHttpClientService _httpClientService;
        private readonly string _controllerName;

        public GenericService(IHttpClientService httpClientService, string controllerName)
        {
            _httpClientService = httpClientService;
            _controllerName = controllerName;
        }

        public async Task<ApiResponse> Get()
        {
            return await _httpClientService.Get($"{_controllerName}/Get", false);
        }

        public async Task<ApiResponse> Get(int id)
        {
            return await _httpClientService.Get($"{_controllerName}/Get", false, id);
        }

        public async Task<ApiResponse> Create(TDto modelDto)
        {
            return await _httpClientService.Post($"{_controllerName}/Create", false, modelDto);
        }

        public async Task<ApiResponse> Edit(int id, TDto modelDto)
        {
            return await _httpClientService.Put($"{_controllerName}/Update", false, id, modelDto);
        }

        public async Task<ApiResponse> Delete(int id)
        {
            return await _httpClientService.Delete($"{_controllerName}/Delete", false, id);
        }
    }
}
