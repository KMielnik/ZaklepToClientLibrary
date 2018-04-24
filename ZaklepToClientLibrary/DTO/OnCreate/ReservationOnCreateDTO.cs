using System;
using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.DTO.OnCreate
{
    public class ReservationOnCreateDto
    {
        public RestaurantOnCreateDto Restaurant { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Table Table { get; set; }
        public CustomerOnCreateDto Customer { get; set; }
    }
}
