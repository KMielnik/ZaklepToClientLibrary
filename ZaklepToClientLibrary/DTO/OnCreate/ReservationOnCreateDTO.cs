using System;
using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.DTO.OnCreate
{
    public class ReservationOnCreateDTO
    {
        public RestaurantOnCreateDTO Restaurant { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Table Table { get; set; }
        public CustomerOnCreateDTO Customer { get; set; }
    }
}
