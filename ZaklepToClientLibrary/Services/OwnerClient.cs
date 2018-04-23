using System.Net.Http;

namespace ZaklepToClientLibrary.Services
{
    public class OwnerClient : HttpClientWithAuthorization
    {
        public OwnerClient(HttpClient client) : base(client)
        {
        }
    }
}