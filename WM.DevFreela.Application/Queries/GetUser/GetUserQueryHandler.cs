using MediatR;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            return new UserDto(user.FullName, user.Email);
        }
    }
}
