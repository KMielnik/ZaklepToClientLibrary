using System;

namespace ZaklepToClientLibrary.Models
{
    public class Jwt
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}