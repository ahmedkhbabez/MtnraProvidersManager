using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_BAL.Dtos.InvitationToTender;
using MtnraProvidersManager_BAL.Dtos.Market;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class MarketProfile : Profile
    {
        public MarketProfile()
        {
            CreateMap<Market, MarketReadDto>()
                .ForMember(
                    dest => dest.Company,
                    opt => opt.MapFrom(src =>
                        new CompanyReadDto { Id = (Guid)src.CompanyId! }
                    ))
                .ForMember(
                    dest => dest.Direction,
                    opt => opt.MapFrom(src =>
                        new DirectionReadDto { Id = src.DirectionId! }
                    ))
                .ForMember(
                    dest => dest.OriginalInvitationToTender,
                    opt => opt.MapFrom(src =>
                        new InvitationToTenderReadDto { Id = src.OriginalInvitationToTenderId ?? Guid.Empty }
                    ));

            CreateMap<MarketReadDto, Market>()
                .ForMember(
                    dest => dest.Company,
                    opt => opt.Ignore())
                .AfterMap((dto, market) =>
                    market.CompanyId = dto.Company!.Id
                );
            CreateMap<MarketStateHistory, MarketStateHistoryReadDto>();
            CreateMap<MarketWriteDto, Market>();
            CreateMap<Market, MarketWriteDto>();
            CreateMap<MarketUpdateDto, Market>();
            CreateMap<Market, MarketUpdateDto>();
        }
    }
}
