using System;
using Confluence.Client.Client;
using Confluence.Client.Middleware;

namespace Example
{
    public class Program
    {
        public static void Main()
        {
            var application = new Example();
            application.run();
        }
    }

    internal class Example
    {
        public void run()
        {
            var endpoint = "http://localhost:1990/confluence/rest/api";
            var factory = new ConfluenceClientFactory(endpoint);

            var credentials = ReadCredentials();
            var client = factory.Create(credentials);

            var id = 123456789;
            var page = client.Content.GetExpandedContentPage(id);
            page.version.number++;
            page.body.storage.value += "<h1>Test</h1>";
            var result = client.Content.PutContentPage(id, page);

            Console.WriteLine($"Updated to version number {result.version.number}");
            Console.Read();
        }

        private Credentials ReadCredentials()
        {
            // Read login
            Console.Write("Enter your login: ");
            var login = Console.ReadLine();
            Console.Write("\n");
            // Read password
            var password = string.Empty;
            Console.Write("Enter your password: ");
            do
            {
                var info = Console.ReadKey(true);
                if (info.Key != ConsoleKey.Backspace &&
                    info.Key != ConsoleKey.Enter)
                {
                    password += info.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (info.Key == ConsoleKey.Backspace &&
                        password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                    else
                    {
                        if (info.Key == ConsoleKey.Enter)
                            break;
                    }
                }
            } while (true);
            Console.Write("\n");
            // Parse it
            var result = new Credentials(login, password);
            return result;
        }
    }

    internal class Credentials : IConfluenceCredentials
    {
        public Credentials(string login, string password)
        {
            Login = login;
            Password = password;
        }
      
        public string Login { get; }
        public string Password { get; }
    }
}
