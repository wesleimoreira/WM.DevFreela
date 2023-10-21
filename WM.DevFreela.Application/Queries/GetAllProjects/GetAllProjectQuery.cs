using MediatR;
using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectQuery : IRequest<IEnumerable<ProjectDto>>
    {
        public GetAllProjectQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
