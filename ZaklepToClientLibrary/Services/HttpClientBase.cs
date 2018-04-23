using System.Net.Http;

namespace ZaklepToClientLibrary.Services
{
    public class HttpClientBase
    {
        protected readonly HttpClient Client;

        protected HttpClientBase(HttpClient client)
        {
            Client = client;
        }
    }
}