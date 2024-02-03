using AutoMapper;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.User;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_BAL.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _repository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public AuthService(
        IRepository<User> repository,
        IMapper mapper,
        IUserService userService,
        IChangesHandler changesHandler)
    {
        _repository = repository;
        _mapper = mapper;
        _userService = userService;
    }
    public bool VerifyCredentials(UserLoginDto request)
    {
        var user = _repository.GetOne(user => user.Username == request.Username);
        return user != null && PasswordService.VerifyPassword(request.Password, user.HashedPassword);
    }
    public UserReadDto Register(UserRegisterDto userDto, string by)
    {
        var user = _mapper.Map<UserRegisterDto, User>(userDto);
        var creator = _userService.GetUserByUsermane(by);
        if (creator != null)
        {
            user.AddedBy = creator.Id;
            user.Creator = creator;
        }

        var createdUser = _repository.Create(user);
        return _mapper.Map<UserReadDto>(createdUser);
    }

    public string GetToken(User user)
        => JwtService.GenerateToken(user);

    public User? GetUserFromUsername(string username)
        => _repository.GetOne(user => user.Username == username);
}
