using MediatR;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;
        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            project.Start();

            await _repository.StartAsync();

            return Unit.Value;
        }
    }
}
