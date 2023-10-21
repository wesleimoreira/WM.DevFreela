using MediatR;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.AddAsync(new User(request.FullName, request.Email, request.BirthDate));
        }
    }
}
