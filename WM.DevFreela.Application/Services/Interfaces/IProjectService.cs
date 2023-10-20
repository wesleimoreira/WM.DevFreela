using WM.DevFreela.Application.InputModels;
using WM.DevFreela.Application.ViewModels;

namespace WM.DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        int Create(CreateProjectInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void Delect(int id);
        void CreateComment(CreateCommentInputmodel inputmodel);
        void Start(int id);
        void Finsh(int id);
    }
}
