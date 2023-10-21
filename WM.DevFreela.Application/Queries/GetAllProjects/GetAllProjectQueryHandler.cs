using MediatR;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, IEnumerable<ProjectDto>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
