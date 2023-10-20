using WM.DevFreela.Application.ViewModels;

namespace WM.DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<SkillViewModel> GetAll();
    }
}
