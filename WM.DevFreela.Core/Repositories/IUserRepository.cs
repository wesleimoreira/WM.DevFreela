using WM.DevFreela.Core.Dtos;
using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto> GetById(int id);
        Task<int> AddAsync(User user);
    }
}
