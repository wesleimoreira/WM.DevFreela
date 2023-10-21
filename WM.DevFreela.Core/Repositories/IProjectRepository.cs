using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetById(int id);
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<int> AddAsync(Project project);
        Task UpdateAsync();
        Task DeleteAsync();
        Task FinishAsync();
        Task StartAsync();

    }
}
