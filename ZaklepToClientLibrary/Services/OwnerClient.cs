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
    public class OwnerClient : HttpClientWithAuthorization
    {
        internal OwnerClient(HttpClient client) : base(client)
        {
        }


        /// <summary>
        /// Login into customer account.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public async Task OwnerLogin(string login, string password)
            => await base.LoginAsync(login, password, "owners/login");

        /// <summary>
        /// Returns owners account.
        /// </summary>
        /// <exception cref="ErrorCodes.UserNotLoggedIn"></exception>
        /// <returns>Owners account</returns>
        public async Task<Owner> GetOwnerAccount(string login)
        {
            var response = await Client.AuthenticatedGetAsync("owners", Token);

            switch (response.StatusCode)
            {

                case System.Net.HttpStatusCode.Gone:
                    throw new ClientException(ErrorCodes.InvalidLoginCredentials, "Invalid login or password.");
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new ClientException(ErrorCodes.InvalidLoginCredentials, "");
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            var owner = JsonConvert.DeserializeObject<Owner>(responseJson);
            return owner;
        }

        /// <summary>
        /// Returns all owners.
        /// </summary>
        /// <returns>All owners.</returns>
        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            var response = await Client.AuthenticatedGetAsync("owners", Token);
            var responseJson = await response.Content.ReadAsStringAsync();
            var allOwners = JsonConvert.DeserializeObject<IEnumerable<Owner>>(responseJson);
            return allOwners;
        }

        /// <summary>
        /// Registers new owner.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// /// <param name="restaurant"></param>
        public async Task RegisterOwner(string login, string password, string firstName, string lastName,
            string email, string phone, Restaurant restaurant)
        {
            var registerOwner = new OwnerOnCreateDto()
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Restaurant = restaurant
            };

            var registerOwnerJson = JsonConvert.SerializeObject(registerOwner);
            var response = await Client.AuthenticatedPostJsonAsync("owners/register",
                new StringContent(registerOwnerJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Update owners account.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task UpdateOwner(string firstName, string lastName,
            string email, string phone)
        {
            var login = base.GetAuthorizedUserLogin();
            var updateOwner = new OwnerOnUpdateDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };

            var updateOwnerJson = JsonConvert.SerializeObject(updateOwner);
            var response = await Client.AuthenticatedPostJsonAsync($"owners/{login}/update",
                new StringContent(updateOwnerJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Change owners password.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task ChangeOwnerssPassword(string oldPassword, string newPassword)
        {
            var login = base.GetAuthorizedUserLogin();
            var changedPassword = new PasswordChange()
            {
                Login = login,
                OldPassword = oldPassword,
                NewPassword = newPassword
            };

            var changedPasswordJson = JsonConvert.SerializeObject(changedPassword);
            var response = await Client.AuthenticatedPostJsonAsync($"owners/{login}/changepassword",
                new StringContent(changedPasswordJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Removes customers account.
        /// </summary>
        public async Task RemoveOwner()
        {
            var login = base.GetAuthorizedUserLogin();
            var response = await Client.AuthenticatedGetAsync($"owners/{login}/remove", Token);

            //TODO exceptions
        }
    }
}