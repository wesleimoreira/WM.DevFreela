using MediatR;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;
using WM.DevFreela.Core.Services;

namespace WM.DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;     

        public CreateUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = _authService.ComputeSha256Hash(request.Password);

            return await _userRepository.AddAsync(new User(request.FullName, request.Email, password, request.Role, request.BirthDate));
        }
    }
}
