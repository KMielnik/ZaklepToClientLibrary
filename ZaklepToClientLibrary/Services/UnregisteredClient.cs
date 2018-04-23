using System.Net.Http;

namespace ZaklepToClientLibrary.Services
{
    public class UnregisteredClient : HttpClientBase
    {
        public UnregisteredClient(HttpClient client) :base(client)
        {
        }
    }
}