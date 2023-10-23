using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task<int> AddAsync(Project project);
        Task UpdateAsync();
        Task DeleteAsync();
        Task FinishAsync();
        Task StartAsync();
    }
}
