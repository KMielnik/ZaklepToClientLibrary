using System.Net.Http;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZaklepToClientLibrary.Exceptions;
using ZaklepToClientLibrary.Extensions;
using ZaklepToClientLibrary.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ZaklepToClientLibrary.DTO.OnCreate;
using ZaklepToClientLibrary.DTO.OnUpdate;

namespace ZaklepToClientLibrary.Services
{
    public class RestaurantClient : HttpClientWithAuthorization
    {
        internal RestaurantClient(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Retusn all restaurants/
        /// </summary>
        /// <returns>All restaurants.</returns>
        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            var response = await Client.AuthenticatedGetAsync("restaurants", Token);
            var responseJson = await response.Content.ReadAsStringAsync();
            var allRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(responseJson);
            return allRestaurants;
        }
    }
}
