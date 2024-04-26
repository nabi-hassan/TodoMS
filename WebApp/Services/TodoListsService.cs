using Applicaton.Dtos;
using Applicaton.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class TodoListsService : GenericService<TodoListDTO>, ITodoListsService
    {
        private readonly IHttpClientService _httpClientService;
        private const string controllerName = "TodoLists";

        public TodoListsService(IHttpClientService httpClientService) : base(httpClientService, controllerName)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiResponse> GetByGroupID(int? gid)
        {
            return await _httpClientService.Get($"{controllerName}/GetByGroupID", false, gid);
        }
    }
}
