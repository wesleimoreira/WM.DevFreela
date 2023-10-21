using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Core.Dtos;
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

        public async Task<IEnumerable<SkillDto>> GetAll()
        {
            return (from skill in await _dbContext.Skills.AsNoTracking().ToListAsync()
                    select new SkillDto(skill.Id, skill.Description, skill.CreatedAt))
                    .ToList();
        }
    }
}
