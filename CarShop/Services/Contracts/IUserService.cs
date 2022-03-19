using CarShop.ViewModels.Users;
using System.Collections.Generic;

namespace CarShop.Services.Contracts
{
    public interface IUserService
    {
        ICollection<string> CreateUser(RegisterFormViewModel model);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        bool IsMechanic(string userId);

        string GetUserId(LoginFormViewModel model);
    }
}
