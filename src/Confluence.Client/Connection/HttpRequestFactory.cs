using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Confluence.Client.Connection
{
    internal static class HttpRequestFactory
    {
        public static HttpRequestMessage Post<TInput>(string endpoint, TInput data) =>
            CreateRequest(endpoint, HttpMethod.Post, data);
        public static HttpRequestMessage Get(string endpoint) =>
            CreateRequest<object>(endpoint, HttpMethod.Get);
        public static HttpRequestMessage Put<TInput>(string endpoint, TInput data) =>
            CreateRequest(endpoint, HttpMethod.Put, data);
        public static HttpRequestMessage Delete(string endpoint) =>
            CreateRequest<object>(endpoint, HttpMethod.Delete);

        private static HttpRequestMessage CreateRequest<TInput>(
            string endpoint,
            HttpMethod method,
            TInput data = default)
        {
            var request = new HttpRequestMessage(method, endpoint);

            if (data == null ||
                (method != HttpMethod.Post && method != HttpMethod.Put))
                return request;
            var body = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return request;
        }
    }
}
