using Applicaton.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class TodoGroupsService : ITodoGroupsService
    {
        private readonly IHttpClientService _httpClientService;

        public TodoGroupsService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiResponse> Get()
        {
            return await _httpClientService.Get("TodoGroups/Get", false);
        }
    }
}
