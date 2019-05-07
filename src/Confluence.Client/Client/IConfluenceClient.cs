using Confluence.Client.Endpoints;

namespace Confluence.Client.Client
{
    public interface IConfluenceClient
    {
        IContentEndpoint Content { get; }
  
    }
}
