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
            var loginJson = await Client.AuthenticatedGetAsync("customers/getmyaccount", Token); //it will be changed
            var login = await loginJson.Content.ReadAsStringAsync(); //it will be changed
            var response = await Client.AuthenticatedGetAsync($"customers/{login}/toprestaurants", Token);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new ClientException(ErrorCodes.UserNotLoggedIn);
            var responseJson = await response.Content.ReadAsStringAsync();
            var mostFrequentRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(responseJson);
            return mostFrequentRestaurants;

        }

        /// <summary>
        /// Registers new customer.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        public async Task RegisterCustomer(string login, string password, string firstName, string lastName,
            string email, string phone)
        {
            var registerCustomer = new CustomerOnCreateDto()
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };

            var registerCustomerJson = JsonConvert.SerializeObject(registerCustomer);
            var response = await Client.AuthenticatedPostJsonAsync("cusomters/register",
                new StringContent(registerCustomerJson), Token);

            //TODO exceptions
        }


        /// <summary>
        /// Update customer account.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task UpdateCustomer(string login, string firstName, string lastName,
            string email, string phone)
        {

            var registerCustomer = new CustomerOnUpdateDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };

            var registerCustomerJson = JsonConvert.SerializeObject(registerCustomer);
            var response = await Client.AuthenticatedPostJsonAsync($"cusomters/{login}/update",
                new StringContent(registerCustomerJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Change customers password.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task ChangeCustomersPassword(string login, string oldPassword, string newPassword)
        {
            var changedPassword = new PasswordChange()
            {
                Login = login,
                OldPassword = oldPassword,
                NewPassword = newPassword
            };

            var changedPasswordJson = JsonConvert.SerializeObject(changedPassword);
            var response = await Client.AuthenticatedPostJsonAsync($"customers/{login}/changepassword", 
                new StringContent(changedPasswordJson), Token);

            //TODO exceptions
        }
    }
}