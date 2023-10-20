using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Application.InputModels;
using WM.DevFreela.Application.Services.Interfaces;
using WM.DevFreela.Application.ViewModels;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Cliente)
                .Include(p => p.Freelancer)
                .FirstOrDefault(p => p.Id == id);

            if (project == null) return default!;

            return new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.ClienteId,
                project.FreelancerId,
                project.TotalCost,
                project.Description,
                project.Cliente.FullName,
                project.Freelancer.FullName);
        }

        public int Create(CreateProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.ClienteId, inputModel.FreelanderId, inputModel.TotalCost, inputModel.Description);

            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = this._dbContext.Projects.SingleOrDefault(x => x.Id == inputModel.Id);

            project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

            _dbContext.SaveChanges();
        }

        public IEnumerable<ProjectViewModel> GetAll(string query)
        {
            return _dbContext.Projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.TotalCost, p.Description, p.CreatedAt))
                .ToList();
        }

        public void CreateComment(CreateCommentInputmodel inputmodel)
        {
            var comment = new ProjectComment(inputmodel.Content, inputmodel.UserId, inputmodel.ProjectId);

            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delect(int id)
        {
            var project = this._dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project?.Cancel();

            _dbContext.SaveChanges();
        }

        public void Finsh(int id)
        {
            var project = this._dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project?.Finish();

            _dbContext.SaveChanges();
        }

        public void Start(int id)
        {
            var project = this._dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project?.Start();

            _dbContext.SaveChanges();
        }
    }
}
