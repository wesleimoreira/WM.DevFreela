using WM.DevFreela.Application.InputModels;
using WM.DevFreela.Application.ViewModels;

namespace WM.DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        int Create(CreateUserInputModel inputModel);
    }
}
