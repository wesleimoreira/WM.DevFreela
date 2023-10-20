using MediatR;
using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.ProjectComments.AddAsync(new ProjectComment(request.Content, request.UserId, request.ProjectId), cancellationToken);

            if (comment.State == EntityState.Added)
                await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
