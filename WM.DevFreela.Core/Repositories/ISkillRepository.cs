using WM.DevFreela.Core.Dtos;

namespace WM.DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillDto>> GetAll();
    }
}
