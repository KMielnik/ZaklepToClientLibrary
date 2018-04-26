using System;
using System.Collections.Generic;
using System.Text;

namespace ZaklepToClientLibrary.Models
{
    public class Table
    {
        public Guid Id { get; set; }
        public int NumberOfSeats { get; set; }
        public (int x, int y) Coordinates { get; set; }

        public Table()
        {
        }

        public Table(Guid id, int numberOfSeats, (int x, int y) coordinates)
        {
            Id = id;
            NumberOfSeats = numberOfSeats;
            Coordinates = coordinates;
        }
    }
}
