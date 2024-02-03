using MtnraProvidersManager_BAL.Dtos.User;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IAuthService
    {
        UserReadDto Register(UserRegisterDto userDto, string by);
        bool VerifyCredentials(UserLoginDto request);
        string GetToken(User user);
        User? GetUserFromUsername(string username);
    }
}
