using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.AsNoTracking().ToListAsync();
        }
    }
}
