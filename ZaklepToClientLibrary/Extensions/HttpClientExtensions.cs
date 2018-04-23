using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ZaklepToClientLibrary.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string requestUri,
            HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = content;
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return await client.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> AuthenticatedGetAsync(this HttpClient client, string requestUri,
            string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");

            return await client.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> AuthenticatedPostJsonAsync(this HttpClient client, string requestUri,
            HttpContent content, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = content;
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");

            return await client.SendAsync(request);
        }
    }
}
