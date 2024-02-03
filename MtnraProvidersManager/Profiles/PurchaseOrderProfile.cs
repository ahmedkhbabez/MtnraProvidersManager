using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.CommonRightContract;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class CommonRightContractProfile : Profile
    {
        public CommonRightContractProfile()
        {
            CreateMap<CommonRightContract, CommonRightContractReadDto>()
                .ForMember(
                    dest => dest.Direction,
                    opt => opt.MapFrom(src =>
                        new DirectionReadDto { Id = src.DirectionId! }
                    ))
                .ForMember(
                    dest => dest.Company,
                    opt => opt.MapFrom(src =>
                        new CompanyReadDto { Id = src.CompanyId! }
                    ));
            CreateMap<CommonRightContractReadDto, CommonRightContract>();
            CreateMap<CommonRightContract, CommonRightContractWriteDto>();
            CreateMap<CommonRightContractWriteDto, CommonRightContract>();
            CreateMap<CommonRightContract, CommonRightContractUpdateDto>();
            CreateMap<CommonRightContractUpdateDto, CommonRightContract>();
        }
    }
}
