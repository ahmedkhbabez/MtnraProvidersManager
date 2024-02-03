using MtnraProvidersManager_BAL.Dtos.User;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserReadDto> GetUsers();
        User? GetUserById(Guid id);
        UserReadDto? GetReadUserById(Guid id);
        User? GetUserByUsermane(string username);
        UserReadDto Update(User user);
        UserReadDto UpdatePassword(User user, string newPassword);
        void Promote(User user);
        void Delete(User user);
        bool Exists(string username, Guid id);
    }
}
