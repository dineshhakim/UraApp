using UraApp.Models;

namespace UraApp.Services.Abstract
{
    public interface IUserService : IServiceCommand<User>
    {
        bool CheckLogin(User user);
    }
}