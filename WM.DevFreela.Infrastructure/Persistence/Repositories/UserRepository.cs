using Microsoft.EntityFrameworkCore;
using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Core.Repositories;

namespace WM.DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> GetById(int id)
        {
            return (from user in await _dbContext.Users.AsNoTracking().ToListAsync()
                    select new UserDto(user.FullName, user.Email)).First();
        }

        public async Task<int> AddAsync(User user)
        {
            var Created = await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return Created.Entity.Id;
        }
    }
}
