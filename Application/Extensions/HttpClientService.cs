using System.Net.Http.Headers;

namespace Application.Extensions
{
    public class HttpClientService(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService)
    {
        private HttpClient CreateClient() => httpClientFactory!.CreateClient(Constant.HttpClientName);
        public HttpClient GetPublicClient() => CreateClient();

        public async Task<HttpClient> GetPrivateClient()
        {
            try
            {
                var client = CreateClient();
                var tokenModel = await localStorageService.GetModelFromToken();
                if (!string.IsNullOrEmpty(tokenModel.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constant.HttpClientHeaderScheme, tokenModel.Token);
                }
                return client;
            }
            catch
            {
                return new HttpClient();
            }
        }
    }
}
