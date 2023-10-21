using MediatR;
using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsDto>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
