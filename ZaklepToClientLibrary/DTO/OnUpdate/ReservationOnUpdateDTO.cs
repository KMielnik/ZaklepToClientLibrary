using System;
using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.DTO.OnUpdate
{
    public class ReservationOnUpdateDTO
    {
        public Guid Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Table Table { get; set; }
        public Customer Customer { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsActive { get; set; }
    }
}
