using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZaklepToClientLibrary.DTO.OnCreate;
using ZaklepToClientLibrary.DTO.OnUpdate;
using ZaklepToClientLibrary.Exceptions;
using ZaklepToClientLibrary.Extensions;
using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.Services
{
    public class EmployeeClient : HttpClientWithAuthorization
    {
        internal EmployeeClient(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Login into employees account.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <exception cref="ErrorCodes.InvalidLoginCredentials"></exception>
        public async Task EmployeeLogin(string login, string password)
            => await base.LoginAsync(login, password, "employee/login");

        /// <summary>
        /// Returns employees account.
        /// </summary>
        /// <exception cref="ErrorCodes.UserNotLoggedIn"></exception>
        /// <returns>Employees account</returns>
        public async Task<Employee> GetEmployeeAccount(string login)
        {
            var response = await Client.AuthenticatedGetAsync("employee", Token);
            var responseJson = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<Employee>(responseJson);
            return employee;

            //TODO exceptions
        }

        /// <summary>
        /// Returns all employees
        /// </summary>
        /// <returns>All employees</returns>
        public async Task<IEnumerable<Employee>> GetAllCEmployees()
        {
            var response = await Client.AuthenticatedGetAsync("$customers", Token);
            var responseJson = await response.Content.ReadAsStringAsync();
            var allEmployees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseJson);
            return allEmployees;
        }

        /// <summary>
        /// Registers new employee.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        public async Task RegisterEmplyeer(string login, string password, string firstName, string lastName,
            string email, string phone)
        {
            var registerEmployee = new EmployeeOnCreateDto()
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };

            var registerEmployeeJson = JsonConvert.SerializeObject(registerEmployee);
            var response = await Client.AuthenticatedPostJsonAsync("employee/register",
                new StringContent(registerEmployeeJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Update employees account.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        public async Task UpdateEmployee(string firstName, string lastName,
            string email, string phone)
        {
            var login = base.GetAuthorizedUserLogin();
            var updateEmployee = new EmployeeOnUpdateDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            };

            var registerEmployeeJson = JsonConvert.SerializeObject(updateEmployee);
            var response = await Client.AuthenticatedPostJsonAsync($"employee/{login}/update",
                new StringContent(registerEmployeeJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Change employees password.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public async Task ChangeEmployeesPassword(string oldPassword, string newPassword)
        {
            var login = base.GetAuthorizedUserLogin();
            var changedPassword = new PasswordChange()
            {
                Login = login,
                OldPassword = oldPassword,
                NewPassword = newPassword
            };

            var changedPasswordJson = JsonConvert.SerializeObject(changedPassword);
            var response = await Client.AuthenticatedPostJsonAsync($"employee/{login}/changepassword",
                new StringContent(changedPasswordJson), Token);

            //TODO exceptions
        }

        /// <summary>
        /// Removes customers account.
        /// </summary>
        public async Task RemoveEmployee()
        {
            var login = base.GetAuthorizedUserLogin();
            var response = await Client.AuthenticatedGetAsync($"employee/{login}/remove", Token);

            //TODO exceptions
        }
    }
}