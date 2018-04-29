﻿using System.Net.Http;
using System.Collections.Generic;
using ZaklepToClientLibrary.Exceptions;
using ZaklepToClientLibrary.Extensions;
using ZaklepToClientLibrary.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ZaklepToClientLibrary.Services
{
    public class CustomerClient : HttpClientWithAuthorization
    {
        internal CustomerClient(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Login into customer account.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <exception cref="ErrorCodes.InvalidLoginCredentials"></exception>
        public async Task CustomerLogin(string login, string password)
            => await base.LoginAsync(login, password, "api/customers/login");


        /// <summary>
        /// Returns customer account.
        /// </summary>
        /// <exception cref="ErrorCodes.UserNotLoggedIn"></exception>
        public async Task<Customer> GetCustommerAccount(string login)
        {
            var response = await Client.AuthenticatedGetAsync("customers",Token);

            switch(response.StatusCode)
            {

                case System.Net.HttpStatusCode.Gone:
                    throw new ClientException(ErrorCodes.InvalidLoginCredentials, "Invalid login or password.");
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new ClientException(ErrorCodes.InvalidLoginCredentials, "");
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(responseJson);
            return customer;
        }

        /// <summary>
        /// Returns customers most frequent restaurants.
        /// </summary>
        /// <exception cref="ErrorCodes.UserNotLoggedIn"></exception>
        public async Task<IEnumerable<Restaurant>> GetMostFrequentRestaurants()
        {
            var login = await Client.AuthenticatedGetAsync("customers/getmyaccount", Token);
            var response = await Client.AuthenticatedGetAsync($"api/customers/{login}/toprestaurants", Token);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new ClientException(ErrorCodes.UserNotLoggedIn);
            var responseJson = await response.Content.ReadAsStringAsync();
            var mostFrequentRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(responseJson);
            return mostFrequentRestaurants;

        }
    }
}