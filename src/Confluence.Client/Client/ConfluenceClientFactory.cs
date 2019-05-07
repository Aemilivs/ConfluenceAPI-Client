using Confluence.Client.Connection;
using Confluence.Client.Middleware;

namespace Confluence.Client.Client
{
    public interface IConfluenceClientFactory
    {
        IConfluenceClient Create(IConfluenceCredentials credentials);
    }

    public sealed class ConfluenceClientFactory
    {
        private readonly string _endpoint;

        public ConfluenceClientFactory(string endpoint)
        {
            _endpoint = endpoint;
        }

        public IConfluenceClient Create(IConfluenceCredentials credentials)
        {
            var connection = new ConfluenceConnection(_endpoint, credentials);
            return new ConfluenceClient(connection);
        }
    }
}
