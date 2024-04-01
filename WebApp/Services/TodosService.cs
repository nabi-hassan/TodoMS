using Applicaton.Dtos;
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

    }
}
