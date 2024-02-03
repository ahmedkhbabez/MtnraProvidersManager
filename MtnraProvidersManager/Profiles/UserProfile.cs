using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.User;
using MtnraProvidersManager_BAL.Services;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            _ = CreateMap<User, UserRegisterDto>();
            _ = CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.HashedPassword, opt => opt.Ignore())
                .AfterMap((dto, user) =>
                {
                    user.Role = "Moderator";
                    user.HashedPassword = PasswordService.HashPassword(dto.Password);
                });
            _ = CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator!.Username));

        }
    }
}
