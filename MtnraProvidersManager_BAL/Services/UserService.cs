using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.User;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services
{
    public class UserService : IUserService
    {
        public readonly IRepository<User> _repository;
        public readonly IMapper _mapper;
        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Delete(User user)
        {
            _repository.DeleteManyByCondition(u => u.AddedBy == user.Id);
            _repository.Delete(user);
        }

        public UserReadDto? GetReadUserById(Guid id)
        {
            var user = GetUserById(id);
            return user == null ? null : _mapper.Map<UserReadDto>(user);
        }

        public User? GetUserById(Guid id)
            => _repository.GetOne(user => user.Id == id);

        public IEnumerable<UserReadDto> GetUsers()
        {
            var users = _repository.GetAll();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public void Promote(User user)
        {
            user.Role = "Admin";
            _repository.Update(user);
        }

        public UserReadDto Update(User user)
        {
            _repository.Update(user!);
            var updatedUser = _repository.GetOne(u => u.Id == user.Id);
            return _mapper.Map<UserReadDto>(updatedUser!);
        }

        public bool Exists(string username, Guid id)
            => _repository.GetOne(u => u.Username == username && u.Id != id) != null;

        public UserReadDto UpdatePassword(User user, string newPassword)
        {
            user.HashedPassword = PasswordService.HashPassword(newPassword);
            return Update(user);
        }

        public User? GetUserByUsermane(string username)
        {
            var user = _repository.GetOne(u => u.Username == username);
            return user;
        }
    }
}
