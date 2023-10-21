using MediatR;
using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
