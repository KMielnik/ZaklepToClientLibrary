using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ZaklepToClientLibrary.Extensions
{
    /// <summary>
    /// HttpClient extensions used for easier operations
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Extension for easier posting json as content to our API
        /// </summary>
        /// <param name="client"></param>
        /// <param name="requestUri">uri of api destination</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string requestUri,
            HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Content = content;
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return await client.SendAsync(request);
        }

        /// <summary>
        /// GET method on api but with authentication token
        /// </summary>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <param name="token">Token you got from API</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> AuthenticatedGetAsync(this HttpClient client, string requestUri,
            string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");

            return await client.SendAsync(request);
        }

        /// <summary>
        /// Authenticated POST for sending JSON to method which need authentication
        /// </summary>
        /// <param name="client"></param>
        /// <param name="requestUri"></param>
        /// <param name="content">Object as Json</param>
        /// <param name="token">Token from API</param>
        /// <returns></returns>
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
