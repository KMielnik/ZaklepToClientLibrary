using ZaklepToClientLibrary.Models;

namespace ZaklepToClientLibrary.DTO.OnCreate
{
    public class EmployeeOnCreateDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
