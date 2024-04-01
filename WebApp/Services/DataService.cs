using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class DataService : IDataService
    {
        private readonly IHttpClientService _httpClientService;
        public ITodoGroupsService TodoGroups { get; }
        public ITodoListsService TodoLists { get; }
        public ITodosService Todos { get; }

        public DataService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            TodoGroups = new TodoGroupsService(_httpClientService);
            TodoLists = new TodoListsService(_httpClientService);
            Todos = new TodosService(_httpClientService);
        }

    }
}
