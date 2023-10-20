using MediatR;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.AddAsync(new Project(request.Title, request.ClienteId, request.FreelanderId, request.TotalCost, request.Description), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Entity.Id;
        }
    }
}
