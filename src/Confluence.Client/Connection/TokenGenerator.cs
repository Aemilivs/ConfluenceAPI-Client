using Confluence.Client.Middleware;
using static System.Text.Encoding;
using Convert = System.Convert;

namespace Confluence.Client.Connection
{
    internal sealed class TokenGenerator
    {
        private readonly IConfluenceCredentials _credentials;
        private readonly string _token;
        public TokenGenerator(IConfluenceCredentials credentials)
        {
            _credentials = credentials;
            _token = CreateToken();
        }

        private string CreateToken()
        {
            var credentials = $"{_credentials.Login}:{_credentials.Password}";
            var bytes = ASCII.GetBytes(credentials);
            var result = Convert.ToBase64String(bytes);
            return result;
        }
        public string GetToken() => _token;
    }
}