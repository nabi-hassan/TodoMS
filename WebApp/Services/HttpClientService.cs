using Applicaton.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApiClient");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
        public async Task<ApiResponse> Get(string path, bool addAuthHeader)
        {
            if (addAuthHeader == false)
            {
                return await GetResponse(path);
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true ? await GetResponse(path) : ApiResponseBuilder.GenerateUnauthorized("Unauthorized", "Unauthorized Access");           
        }
        private Task<bool> AddAuthHeader()
        {
            throw new NotImplementedException();
        }

        private async Task<ApiResponse> GetResponse(string path)
        {
            var httpResponseMessage = await _httpClient.GetAsync(path);
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }
}
