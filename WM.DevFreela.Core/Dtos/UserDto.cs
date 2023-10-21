namespace WM.DevFreela.Core.Dtos
{
    public class UserDto
    {
        public UserDto(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
