using Applicaton.Dtos;
using Applicaton.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class TodosService : GenericService<TodoDTO>, ITodosService
    {
        private readonly IHttpClientService _httpClientService;
        private const string controllerName = "Todos";

        public TodosService(IHttpClientService httpClientService) : base(httpClientService, controllerName)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiResponse> GetByListID(int? lid)
        {
            return await _httpClientService.Get($"{controllerName}/GetByListID", false, lid);
        }
    }
}
