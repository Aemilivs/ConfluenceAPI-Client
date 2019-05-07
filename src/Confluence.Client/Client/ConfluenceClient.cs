using Confluence.Client.Connection;
using Confluence.Client.Endpoints;

namespace Confluence.Client.Client
{
    internal class ConfluenceClient : IConfluenceClient
    {
        private readonly IConfluenceConnection _connection;

        public ConfluenceClient(IConfluenceConnection connection)
        {
            _connection = connection;
        }

        private IContentEndpoint _content;
        public IContentEndpoint Content => _content ?? (_content = new ContentEndpoint(_connection));
    }
}
