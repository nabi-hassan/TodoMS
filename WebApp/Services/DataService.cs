using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class DataService : IDataService
    {
        private readonly IHttpClientService _httpClientService;
        public ITodoGroupsService TodoGroups { get; }

        public DataService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            TodoGroups = new TodoGroupsService(_httpClientService);
        }

    }
}
