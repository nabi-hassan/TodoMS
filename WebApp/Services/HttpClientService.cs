using Applicaton.Helpers;
using System.Net.Http.Json;
using System.Reflection;
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

        public async Task<ApiResponse> Get(string path, bool addAuthHeader, int id)
        {
            if (addAuthHeader == false)
            {
                return await GetResponse(path, id);
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true ? await GetResponse(path, id) : ApiResponseBuilder.GenerateUnauthorized("Unauthorized", "Unauthorized Access");
        }

        public async Task<ApiResponse> Post(string path, bool addAuthHeader, object model)
        {
            if (addAuthHeader == false)
            {
                return await PostResponse(path, model);
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true ? await PostResponse(path, model) : ApiResponseBuilder.GenerateUnauthorized("Unauthorized", "Unauthorized Access");
        }

        public async Task<ApiResponse> Put(string path, bool addAuthHeader, int id, object model)
        {
            if (addAuthHeader == false)
            {
                return await PutResponse(path, id, model);
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true ? await PutResponse(path, id, model) : ApiResponseBuilder.GenerateUnauthorized("Unauthorized", "Unauthorized Access");
        }

        public async Task<ApiResponse> Delete(string path, bool addAuthHeader, int id)
        {
            if (addAuthHeader == false)
            {
                return await DeleteResponse(path, id);
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true ? await DeleteResponse(path, id) : ApiResponseBuilder.GenerateUnauthorized("Unauthorized", "Unauthorized Access");
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

        private async Task<ApiResponse> GetResponse(string path, int id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"{path}/{id}");
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResponse>();
        }

        private async Task<ApiResponse> PostResponse(string path, object model)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync(path, model);
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResponse>();
        }

        private async Task<ApiResponse> PutResponse(string path, int id, object model)
        {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync($"{path}/{id}", model);
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResponse>();
        }
        private async Task<ApiResponse> DeleteResponse(string path, int id)
        {
            var httpResponseMessage = await _httpClient.DeleteAsync($"{path}/{id}");
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }
}
