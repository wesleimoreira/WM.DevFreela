using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllAsync();
    }
}
