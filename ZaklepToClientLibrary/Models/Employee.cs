using System;
using System.Collections.Generic;
using System.Text;

namespace ZaklepToClientLibrary.Models
{
    public class Employee
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public Restaurant Restaurant { get; set; }

        public Employee()
        {
        }

        public Employee(string login, string firstrName, string lastName, string email, string phone, DateTime createdAt, Restaurant restaurant)
        {
            Login = login;
            FirstName = firstrName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
            Restaurant = restaurant;
        }
    }
}
