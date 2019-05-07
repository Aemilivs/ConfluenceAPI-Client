namespace Confluence.Client.Middleware
{
    public interface IConfluenceCredentials
    {
        string Login { get; }
        string Password { get; }
    }
}