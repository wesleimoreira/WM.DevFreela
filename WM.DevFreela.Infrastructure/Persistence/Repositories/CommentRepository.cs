using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public CommentRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
