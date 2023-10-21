using MediatR;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(new Project(request.Title, request.ClienteId, request.FreelanderId, request.TotalCost, request.Description));
        }
    }
}
