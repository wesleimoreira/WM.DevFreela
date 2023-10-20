using WM.DevFreela.Application.InputModels;
using WM.DevFreela.Application.Services.Interfaces;
using WM.DevFreela.Application.ViewModels;
using WM.DevFreela.Core.Entities;
using WM.DevFreela.Infrastructure.Persistence;

namespace WM.DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null) return default!;

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
