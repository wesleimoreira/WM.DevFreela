using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Core.Repositories
{
    public interface ICommentRepository
    {
        Task AddAsync(ProjectComment projectComment);
    }
}
