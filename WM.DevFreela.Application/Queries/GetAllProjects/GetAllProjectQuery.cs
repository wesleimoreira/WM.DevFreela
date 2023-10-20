using MediatR;

namespace WM.DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectQuery : IRequest<IEnumerable<ProjectViewModel>>
    {
        public GetAllProjectQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
