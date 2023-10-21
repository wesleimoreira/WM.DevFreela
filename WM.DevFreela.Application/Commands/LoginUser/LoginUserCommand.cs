using MediatR;
using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
