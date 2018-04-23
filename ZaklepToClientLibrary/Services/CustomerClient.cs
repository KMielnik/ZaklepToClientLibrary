using System.Net.Http;

namespace ZaklepToClientLibrary.Services
{
    public class CustomerClient : HttpClientWithAuthorization
    {
        public CustomerClient(HttpClient client) : base(client)
        {
        }
    }
}