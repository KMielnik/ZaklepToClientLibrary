using System;
using System.Collections.Generic;
using System.Text;

namespace ZaklepToClientLibrary.Models
{
    public class Owner
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public Restaurant Restaurant { get; set; }

        public Owner()
        {
        }

        public Owner(string login, string firstrName, string lastName, string email, string phone, DateTime createdAt, Restaurant restaurant)
        {
            Login = login;
            firstrName = FirstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            CreatedAt = createdAt;
            Restaurant = restaurant;
        }
    }
}
