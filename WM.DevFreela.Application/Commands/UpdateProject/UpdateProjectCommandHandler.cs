using MediatR;
using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;

        public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (project == null) return 0;

            project.Update(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
