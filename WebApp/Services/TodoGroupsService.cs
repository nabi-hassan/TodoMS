using Applicaton.Dtos;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class TodoGroupsService : GenericService<TodoGroupDTO>, ITodoGroupsService
    {
        private readonly IHttpClientService _httpClientService;
        private const string controllerName = "TodoGroups";

        public TodoGroupsService(IHttpClientService httpClientService) : base(httpClientService, controllerName)
        {
            _httpClientService = httpClientService;
        }

    }
}
