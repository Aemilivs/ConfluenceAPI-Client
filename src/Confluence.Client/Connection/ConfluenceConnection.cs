using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Confluence.Client.Middleware;
using Newtonsoft.Json;

namespace Confluence.Client.Connection
{
    public class ConfluenceConnection : IConfluenceConnection
    {
        private static HttpClient _httpClient;
        private TokenGenerator _generator;
        public string ServiceUrl { get; }

        static ConfluenceConnection()
        {
            var handler = new HttpClientHandler();
            _httpClient = new HttpClient(handler);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ConfluenceConnection(string serviceUrl, IConfluenceCredentials credentials)
        {
            ServiceUrl = serviceUrl.Trim('/');
            _generator = new TokenGenerator(credentials);
        }

        public TOutput Get<TOutput>(string endpoint)
        {
            var request = HttpRequestFactory.Get(endpoint);
            return Send<TOutput>(request);
        }

        public Task<TOutput> GetAsync<TOutput>(string endpoint)
        {
            var request = HttpRequestFactory.Get(endpoint);
            return SendAsync<TOutput>(request);
        }

        public TOutput Post<TInput, TOutput>(string endpoint, TInput data)
        {
            var request = HttpRequestFactory.Post(endpoint, data);
            return Send<TOutput>(request);
        }

        public Task<TOutput> PostAsync<TInput, TOutput>(string endpoint, TInput data)
        {
            var request = HttpRequestFactory.Post(endpoint, data);
            return SendAsync<TOutput>(request);
        }

        public TOutput Put<TInput, TOutput>(string endpoint, TInput data)
        {
            var request = HttpRequestFactory.Put(endpoint, data);
            return Send<TOutput>(request);
        }

        public Task<TOutput> PutAsync<TInput, TOutput>(string endpoint, TInput data)
        {
            var request = HttpRequestFactory.Put(endpoint, data);
            return SendAsync<TOutput>(request);
        }

        public TOutput Delete<TOutput>(string endpoint)
        {
            var request = HttpRequestFactory.Delete(endpoint);
            return Send<TOutput>(request);
        }

        public Task<TOutput> DeleteAsync<TOutput>(string endpoint)
        {
            var request = HttpRequestFactory.Delete(endpoint);
            return SendAsync<TOutput>(request);
        }

        private TOutput Send<TOutput>(HttpRequestMessage request)
        {
            SetHeaders(request.Headers);

            var response = _httpClient.SendAsync(request).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            response.EnsureSuccessStatusCode();

            var result = Convert<TOutput>(content);
            return result;
        }

        private TOutput Convert<TOutput>(string input)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            return JsonConvert.DeserializeObject<TOutput>(input, settings);
        }

        private async Task<TOutput> SendAsync<TOutput>(HttpRequestMessage request)
        {
            SetHeaders(request.Headers);

            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var content = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TOutput>(content);
        }

        private void SetHeaders(HttpRequestHeaders headers)
        {
            headers.Authorization = new AuthenticationHeaderValue("Basic", _generator.GetToken());
        }
    }
}