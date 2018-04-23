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
    }
}
