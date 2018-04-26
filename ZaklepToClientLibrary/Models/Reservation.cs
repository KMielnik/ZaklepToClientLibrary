using System;

namespace ZaklepToClientLibrary.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsActive { get; set; }

        public Reservation()
        {
        }

        public Reservation(Guid id, Restaurant restaurant, DateTime dateStart, DateTime dateEnd, Table table,
           Customer customer, bool isConfirmed, bool isActive)
        {
            Id = id;
            Restaurant = restaurant;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Table = table;
            Customer = customer;
            IsConfirmed = isConfirmed;
            IsActive = isActive;
        }
    }
}