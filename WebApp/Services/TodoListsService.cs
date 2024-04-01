using Applicaton.Dtos;
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

    }
}
