using System.Threading.Tasks;
using Confluence.Client.Connection;
using Confluence.Client.DTO;
using Confluence.Client.Endpoints;

namespace Confluence.Client.Endpoints
{
    public interface IContentEndpoint
    {
        ContentPage GetContentPage(int id);
        Task<ContentPage> GetContentPageAsync(int id);

        ContentPage GetExpandedContentPage(int id);
        Task<ContentPage> GetExpandedContentPageWithBodyAsync(int id);

        ContentPage PutContentPage(int id, ContentPage page);
        Task<ContentPage> PutContentPageAsync(int id, ContentPage page);
    }

    internal class ContentEndpoint : ConfluenceEndpoint, IContentEndpoint
    {
       protected override string EndpointUrl => "content";
     
       public ContentEndpoint(IConfluenceConnection connection) : base(connection) { }
    
       public ContentPage GetContentPage(int id) => Get<ContentPage>($"{id}");
       public Task<ContentPage> GetContentPageAsync(int id) => GetAsync<ContentPage>($"{id}");
    
       public ContentPage GetExpandedContentPage(int id) => Get<ContentPage>($"{id}?expand=version,body.storage,history");
       public Task<ContentPage> GetExpandedContentPageWithBodyAsync(int id) => GetAsync<ContentPage>($"{id}?expand=version,body.storage,history");
    
       public ContentPage PutContentPage(int id, ContentPage page) => Put<ContentPage, ContentPage>($"{id}", page);
       public Task<ContentPage> PutContentPageAsync(int id, ContentPage page) => PutAsync<ContentPage, ContentPage>($"{id}", page);
    }
}
