using System.Net.Http;
using System.Net.Http.Headers;

namespace LivepeerTest.Infrastructure.Services.Livepeer
{
    public class LivepeerClient
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public LivepeerClient(string apiKey)
        {
            _apiKey = apiKey;
            _client = new HttpClient();

            _client.BaseAddress = new Uri("https://livepeer.studio");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public HttpClient Client => _client;
    }
}
