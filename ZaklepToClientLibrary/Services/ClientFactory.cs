using System;
using System.IO;
using System.Net.Http;

namespace ZaklepToClientLibrary.Services
{
    public class ClientFactory
    {
        private CustomerClient customerClient;
        private EmployeeClient employeeClient;
        private OwnerClient ownerClient;
        private UnregisteredClient unregisteredClient;

        private readonly HttpClient client;

        /// <summary>
        /// Create factory which returns single instances of particuliar clients, you can use all of them at once.
        /// </summary>
        /// <param name="apiServerAdress">
        /// Adress of API server which you would like to use
        /// like "localhost","74.12.156.11","www.apiadrress.com"
        /// </param>
        public ClientFactory(string apiServerAdress)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"http://{apiServerAdress}/api/")
            };
        }

        /// <summary>
        /// Create factory which returns single instances of particuliar clients, you can use all of them at once.
        /// <para /> Server adress is taken from the serverAdress.config file.
        /// <para /> If Empty, defaults to localhost.
        /// </summary>
        public ClientFactory() : this(GetServerAdressFromFile())
        {
        }

        private static string GetServerAdressFromFile()
        {
            string serverAdress;
            const string fileName = "serverAdress.config";

            if (File.Exists(fileName))
                serverAdress = File.ReadAllText(fileName);
            else
            {
                serverAdress = "localhost"; //TODO default api adress
                File.WriteAllText(fileName, serverAdress);
            }

            return serverAdress;
        }

        ~ClientFactory() => client.Dispose();

        /// <summary>
        /// Get instance of CustomerClient
        /// </summary>
        public CustomerClient GetCustomerClient()
            => customerClient ?? (customerClient = new CustomerClient(client));

        /// <summary>
        /// Get instance of EmployeeClient
        /// </summary>
        public EmployeeClient GetEmployeeClient()
            => employeeClient ?? (employeeClient = new EmployeeClient(client));

        /// <summary>
        /// Get instance of OwnerClient
        /// </summary>
        public OwnerClient GetOwnerClient()
            => ownerClient ?? (ownerClient = new OwnerClient(client));

        /// <summary>
        /// Get instance of UnregisteredClient
        /// </summary>
        public UnregisteredClient GetUnregisteredClient()
            => unregisteredClient ?? (unregisteredClient = new UnregisteredClient(client));
    }
}