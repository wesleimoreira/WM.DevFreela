namespace WM.DevFreela.Core.Dtos
{
    public class LoginUserDto
    {
        public LoginUserDto(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
