using MediatR;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;
        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            project.Cancel();

            await _repository.DeleteAsync();

            return Unit.Value;
        }
    }
}
