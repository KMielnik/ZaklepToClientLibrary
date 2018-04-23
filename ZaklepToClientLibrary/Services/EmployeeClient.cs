using System.Net.Http;

namespace ZaklepToClientLibrary.Services
{
    public class EmployeeClient : HttpClientWithAuthorization
    {
        public EmployeeClient(HttpClient client) : base(client)
        {
        }
    }
}