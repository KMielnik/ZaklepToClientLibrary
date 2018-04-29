using System.Net.Http;
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
        /// <returns>Customer</returns>
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


    }
}