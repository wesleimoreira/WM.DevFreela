using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> GetById(int id)
        {
            return await _dbContext.Projects.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            return (from project in await _dbContext.Projects.AsNoTracking().ToListAsync()
                    select new ProjectDto(project.Id, project.Title, project.TotalCost, project.Description, project.CreatedAt)).ToList();
        }

        public async Task<int> AddAsync(Project project)
        {
            var projetc = await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();

            return projetc.Entity.Id;
        }

        public async Task UpdateAsync() => await _dbContext.SaveChangesAsync();
        public async Task DeleteAsync() => await _dbContext.SaveChangesAsync();
        public async Task FinishAsync() => await _dbContext.SaveChangesAsync();
        public async Task StartAsync() => await _dbContext.SaveChangesAsync();
    }
}
