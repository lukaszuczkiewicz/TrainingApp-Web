namespace Application.IdentityAndAccess.Services
{
    public class LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
