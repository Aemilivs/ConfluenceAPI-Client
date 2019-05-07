using System.Threading.Tasks;
using Confluence.Client.Connection;

namespace Confluence.Client.Endpoints
{
    internal abstract class ConfluenceEndpoint
    {
        protected IConfluenceConnection Connection { get; }
        protected abstract string EndpointUrl { get; }

        protected ConfluenceEndpoint(IConfluenceConnection connection) => Connection = connection;

        protected TOutput Get<TOutput>(string relativeUrl)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.Get<TOutput>(endpoint);
        }

        protected Task<TOutput> GetAsync<TOutput>(string relativeUrl)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.GetAsync<TOutput>(endpoint);
        }

        protected TOutput Post<TInput, TOutput>(string relativeUrl, TInput data)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.Post<TInput, TOutput>(endpoint, data);
        }

        protected Task<TOutput> PostAsync<TInput, TOutput>(string relativeUrl, TInput data)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.PostAsync<TInput,TOutput>(endpoint, data);
        }

        protected TOutput Put<TInput, TOutput>(string relativeUrl, TInput data)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.Put<TInput, TOutput>(endpoint, data);
        }

        protected Task<TOutput> PutAsync<TInput, TOutput>(string relativeUrl, TInput data)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.PutAsync<TInput,TOutput>(endpoint, data);
        }

        protected TOutput Delete<TOutput>(string relativeUrl)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.Delete<TOutput>(endpoint);
        }

        protected Task<TOutput> DeleteAsync<TOutput>(string relativeUrl)
        {
            var endpoint = GetEndpoint(relativeUrl);
            return Connection.DeleteAsync<TOutput>(endpoint);
        }

        private string GetEndpoint(string relativeUrl)
        {
            var result = $"{Connection.ServiceUrl}/{EndpointUrl}";

            if (!string.IsNullOrEmpty(relativeUrl))
                result += $"/{relativeUrl}";

            return result;
        }
    }
}
