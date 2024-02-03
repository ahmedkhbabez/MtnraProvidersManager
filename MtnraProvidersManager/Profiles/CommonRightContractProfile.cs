using AutoMapper;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_BAL.Dtos.Direction;
using MtnraProvidersManager_BAL.Dtos.PurchaseOrder;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_PAL.Profiles
{
    public class PurchaseOrderProfile : Profile
    {
        public PurchaseOrderProfile()
        {
            CreateMap<PurchaseOrder, PurchaseOrderReadDto>()
                .ForMember(
                    dest => dest.Direction,
                    opt => opt.MapFrom(src =>
                        new DirectionReadDto { Id = src.DirectionId! }
                    ))
                .ForMember(
                    dest => dest.Company,
                    opt => opt.MapFrom(src =>
                        new CompanyReadDto { Id = (Guid)src.CompanyId! }
                    ));
            CreateMap<PurchaseOrderReadDto, PurchaseOrder>();
            CreateMap<PurchaseOrder, PurchaseOrderWriteDto>();
            CreateMap<PurchaseOrderWriteDto, PurchaseOrder>();
            CreateMap<PurchaseOrder, PurchaseOrderUpdateDto>();
            CreateMap<PurchaseOrderUpdateDto, PurchaseOrder>();
        }
    }
}
