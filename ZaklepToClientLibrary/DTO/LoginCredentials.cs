namespace ZaklepToClientLibrary.DTO
{
    public class LoginCredentials
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public LoginCredentials(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}